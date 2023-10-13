using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Xml;
using System.Security.Cryptography;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Collections;
using System.Security.Principal;
using static OfficeOpenXml.ExcelErrorValue;
using SQLiteDatabaseApp.DataBase.Tables;

namespace SQLiteDatabaseApp.DataBase.Manager
{
    internal class DatabaseManager
    {
        private static DatabaseManager instance;
        private string connectionString;

        private DatabaseManager(string dbFilePath)
        {
            connectionString = $"Data Source={dbFilePath};Version=3;";
            InitializeDatabase();
        }

        public static DatabaseManager GetInstance(string dbFilePath)
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new DatabaseManager(dbFilePath);
                }
            }
            return instance;
        }

        public static DatabaseManager GetInstance()
        {
            return instance;
        }

        private void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create table Users
                string createUsersTableSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    ID INTEGER PRIMARY KEY,
                    Username TEXT UNIQUE,
                    Password TEXT,
                    Role TEXT
                )";
                using (SQLiteCommand command = new SQLiteCommand(createUsersTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Create table Modes
                string createModesTableSql = @"
                CREATE TABLE IF NOT EXISTS Modes (
                    ID INTEGER PRIMARY KEY,
                    Name TEXT,
                    MaxBottleNumber INTEGER,
                    MaxUsedTips INTEGER
                )";
                using (SQLiteCommand command = new SQLiteCommand(createModesTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Create table Steps
                string createStepsTableSql = @"
                CREATE TABLE IF NOT EXISTS Steps (
                    ID INTEGER PRIMARY KEY,
                    ModeId INTEGER NULL,
                    Timer DOUBLE,
                    Destination TEXT,
                    Speed DOUBLE,
                    Type TEXT,
                    Volume DOUBLE,
                    FOREIGN KEY (ModeId) REFERENCES Modes(ID) ON DELETE CASCADE
                )";
                using (SQLiteCommand command = new SQLiteCommand(createStepsTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public Users GetUserByUsername(string username)
        {
            if (connectionString == null)
            {
                return null;
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectUserSql = "SELECT * FROM Users WHERE Username = @Username";
                using (SQLiteCommand command = new SQLiteCommand(selectUserSql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Role = reader.GetString(reader.GetOrdinal("Role"))
                            };
                            return user;
                        }
                    }
                }
                connection.Close();
            }
            return null;
        }

        public string HashPassword(string password)
        {
            if (password == null)
            {
                return password;
            }
            string passwordHash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            return passwordHash;
        }

        public void AddNewEntity(ITableEntity entity)
        {
            string tableName = entity.GetType().Name;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var properties = entity.GetType().GetProperties();

                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                string insertSql = $"INSERT INTO {tableName} ({string.Join(", ", properties.Select(p => p.Name))}) VALUES ({string.Join(", ", properties.Select(p => "@" + p.Name))})";

                using (SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection))
                {
                    foreach (var property in properties)
                    {
                        if (property.Name == "ID")
                        {
                            insertCommand.Parameters.AddWithValue("@" + property.Name, GetTableRecordCount(tableName) + 1);
                        }
                        else
                        {
                            var value = property.GetValue(entity);
                            insertCommand.Parameters.AddWithValue("@" + property.Name, value);
                        }
                    }

                    insertCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteData(string tableName, int rowId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {tableName} WHERE ID = @RowID", connection))
                        {
                            command.Parameters.AddWithValue("@RowID", rowId);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        transaction.Rollback();
                    }
                }
                connection.Close();
            }
        }

        public void UpdateID(string tableName, int deletedID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand($"UPDATE {tableName} SET ID = ID - 1 WHERE ID > @DeletedID", connection))
                {
                    command.Parameters.AddWithValue("@DeletedID", deletedID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void UpdateModeID(string tableName, int deletedID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand($"UPDATE {tableName} SET ModeId = ModeId - 1 WHERE ModeId > @DeletedID", connection))
                {
                    command.Parameters.AddWithValue("@DeletedID", deletedID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<string> GetAllTableNames()
        {
            List<string> tableNames = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                DataTable tables = connection.GetSchema("Tables");

                foreach (DataRow row in tables.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    if (!tableName.Equals("sqlite_sequence"))
                        tableNames.Add(tableName);
                }

                connection.Close();
            }
            return tableNames;
        }

        public int GetTableRecordCount(string tableName)
        {
            int rowCount = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT(*) FROM {tableName}", connection))
                {
                    rowCount = Convert.ToInt32(command.ExecuteScalar());
                }

                connection.Close();
            }
            return rowCount;
        }

        public bool CheckIfForeignKeyReference(string tableName, string foreignKeyName, object value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $"PRAGMA foreign_key_list({tableName});";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string foreignKeyColumn = reader["from"].ToString();
                        string referencedTable = reader["table"].ToString();
                        string referencedColumn = reader["to"].ToString();
                        if (foreignKeyColumn == foreignKeyName)
                        {
                            if (PrimaryKeyExistsInParentTable(referencedTable, referencedColumn, value))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void ReorderPrimaryKeys(string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Create a temporary table without primary keys
                        using (SQLiteCommand createTempTable = new SQLiteCommand(
                            $"CREATE TABLE temp_table AS SELECT ModeId, Timer, Destination, Speed, Type, Volume  FROM {tableName}", connection))
                        {
                            createTempTable.ExecuteNonQuery();
                        }

                        // Delete the original table
                        using (SQLiteCommand dropTable = new SQLiteCommand($"DROP TABLE {tableName}", connection))
                        {
                            dropTable.ExecuteNonQuery();
                        }

                        // Create a source table with the correct structure and primary key (auto-increment)
                        using (SQLiteCommand createNewTable = new SQLiteCommand(
                            $"CREATE TABLE {tableName} (ID INTEGER PRIMARY KEY AUTOINCREMENT, ModeId INTEGER NULL, Timer DOUBLE, Destination TEXT, Speed DOUBLE, Type TEXT, Volume DOUBLE, FOREIGN KEY (ModeId) REFERENCES Modes(ID) ON DELETE CASCADE)", connection))
                        {
                            createNewTable.ExecuteNonQuery();
                        }

                        // Insert the data from the temporary table into the source table
                        using (SQLiteCommand copyData = new SQLiteCommand(
                            $"INSERT INTO {tableName} SELECT NULL, ModeId, Timer, Destination, Speed, Type, Volume FROM temp_table", connection))
                        {
                            copyData.ExecuteNonQuery();
                        }

                        // Delete the temporary table
                        using (SQLiteCommand dropTempTable = new SQLiteCommand("DROP TABLE temp_table", connection))
                        {
                            dropTempTable.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                connection.Close();
            }
        }

        public void UpdateData<T>(string tableName, string columnName, T newValue, int rowId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteCommand command = new SQLiteCommand($"UPDATE {tableName} SET {columnName} = @NewValue WHERE ID = @RowID", connection))
                {
                    command.Parameters.AddWithValue("@NewValue", newValue);
                    command.Parameters.AddWithValue("@RowID", rowId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataTable(string tableName)
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectModesSql = "SELECT * FROM " + tableName;
                using (SQLiteCommand command = new SQLiteCommand(selectModesSql, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                connection.Close();
            }
            return dataTable;
        }

        private List<string> GetForeignKeyColumns(string tableName)
        {
            var foreignKeyColumns = new List<string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA foreign_key_list(" + tableName + ")";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["from"].ToString();
                            foreignKeyColumns.Add(columnName);
                        }
                    }
                }
                connection.Clone();
            }
            return foreignKeyColumns;
        }

        public bool PrimaryKeyExistsInParentTable(string parentTableName, string primaryKeyColumnName, object primaryKeyValue)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM {parentTableName} WHERE {primaryKeyColumnName} = @PrimaryKeyValue";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void InsertDataTableIntoSQLite(string tableName, DataTable dataTable)
        {
            bool was_error = false;
            int count = GetTableRecordCount(tableName);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = $"INSERT INTO {tableName} ({string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}) VALUES ({string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => "@" + c.ColumnName))})";

                        var foreignKeyColumns = GetForeignKeyColumns(tableName);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            command.Parameters.Clear();
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                if (column.ColumnName == "ID")
                                {
                                    command.Parameters.AddWithValue("@" + column.ColumnName, ++count);
                                }
                                else
                                {
                                    if (foreignKeyColumns.Contains(column.ColumnName))
                                    {
                                        if (CheckIfForeignKeyReference(tableName, column.ColumnName, row[column]))
                                        {
                                            command.Parameters.AddWithValue("@" + column.ColumnName, row[column]);
                                        }
                                        else
                                        {
                                            command.Parameters.AddWithValue("@" + column.ColumnName, DBNull.Value);
                                            was_error = true;
                                        }
                                    }
                                    else
                                    {
                                        command.Parameters.AddWithValue("@" + column.ColumnName, row[column]);
                                    }
                                }
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
            }
            if (was_error)
            {
                MessageBox.Show("Some foreign key values were not set, \n" +
                    "so they referred to non-existent records in the parent table.");
            }
        }

        public DataTable ExcelDataToDataTable(string filePath, string sheetName, bool hasHeader = true)
        {
            var dt = new DataTable();
            var fi = new FileInfo(filePath);
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exist");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var xlPackage = new ExcelPackage(fi);

            if (xlPackage == null)
                throw new Exception("ExcelPackage is null");

            var worksheet = xlPackage.Workbook.Worksheets[sheetName];

            if (worksheet == null)
                throw new Exception("Worksheet '" + sheetName + "' does not exist in the Excel file.");

            dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
            {
                c.FirstRowIsColumnNames = hasHeader;
            });

            return dt;
        }
    }
}