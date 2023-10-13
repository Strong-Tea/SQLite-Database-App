using SQLiteDatabaseApp.DataBase.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteDatabaseApp.windows
{
    public partial class DataGridWindow : Form
    {

        public DataGridView MyDataGridView { get { return dataGridView; } }


        public DataGridWindow()
        {
            InitializeComponent();
            cbTables.DataSource = DatabaseManager.GetInstance().GetAllTableNames();
            SetDesireWidthColumn(300);
        }

        private void SetDesireWidthColumn(int width)
        {
            int columnNumber = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (columnNumber == 0)
                {
                    columnNumber++;
                    continue;
                }
                column.Width = width;
                columnNumber++;
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedRows();
            }
        }

        private void DeleteSelectedRows()
        {
            List<DataGridViewCell> cellsToRemove = new List<DataGridViewCell>();
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in MyDataGridView.Rows)
            {
                bool allCellsSelected = true;
                for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                {
                    if (!row.Cells[cellIndex].Selected)
                    {
                        allCellsSelected = false;
                        break;
                    }
                }

                if (allCellsSelected)
                {
                    rowsToRemove.Add(row);
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Selected)
                        {
                            cellsToRemove.Add(cell);
                        }
                    }
                }
            }

            // Update a field in the database
            string update_error = null;
            foreach (DataGridViewCell cell in cellsToRemove)
            {
                if (!cell.IsInEditMode && cell.OwningColumn.Name != "ID")
                {
                    try
                    {
                        if (cell.Value is int || cell.Value is long || cell.Value is double || cell.Value is float)
                        {
                            DatabaseManager.GetInstance().UpdateData(
                                cbTables.SelectedItem.ToString(),
                                MyDataGridView.Columns[cell.ColumnIndex].Name,
                                0,
                                 Convert.ToInt32(MyDataGridView.Rows[cell.RowIndex].Cells[0].Value)
                            );
                            cell.Value = 0;
                        }
                        else if (cell.Value is string)
                        {
                            DatabaseManager.GetInstance().UpdateData(
                                cbTables.SelectedItem.ToString(),
                                MyDataGridView.Columns[cell.ColumnIndex].Name,
                                "",
                                Convert.ToInt32(MyDataGridView.Rows[cell.RowIndex].Cells[0].Value)
                            );
                            cell.Value = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        update_error = ex.Message;
                    }
                }
            }
            if (update_error != null)
            {
                MessageBox.Show(update_error);
            }

            int shift_indexes = -1;
            if (rowsToRemove.Count > 0)
            {
                shift_indexes = rowsToRemove[0].Index;
            }

            DatabaseManager database = DatabaseManager.GetInstance();
            foreach (DataGridViewRow row in rowsToRemove)
            {
                if (!row.IsNewRow)
                {                   
                    database.DeleteData(cbTables.SelectedItem.ToString(), row.Index + 1);
                }
            }

            foreach (DataGridViewRow row in rowsToRemove)
            {
                if (!row.IsNewRow)
                {
                    database.UpdateID(cbTables.SelectedItem.ToString(), row.Index + 1);
                    if (cbTables.SelectedItem.ToString().Equals("Modes"))
                    {
                        database.UpdateModeID("Steps", row.Index + 1);
                    }
                    MyDataGridView.Rows.Remove(row);
                }
            }
            if (shift_indexes > -1)
            {
                for (int i = shift_indexes; i < dataGridView.Rows.Count - 1; i++)
                {
                    dataGridView.Rows[i].Cells[0].Value = i + 1;
                }
            }

            if (cbTables.SelectedItem.ToString().Equals("Modes"))
            {
                database.ReorderPrimaryKeys("Steps");
            }
        }

        private void btImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = " Choose file";
                openFileDialog.Filter = "Files Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string selectedTableName = cbTables.SelectedItem.ToString();
                    try
                    {
                        var data = DatabaseManager.GetInstance().ExcelDataToDataTable(selectedFilePath, selectedTableName);
                        DatabaseManager.GetInstance().InsertDataTableIntoSQLite(selectedTableName, data);
                        MyDataGridView.DataSource = DatabaseManager.GetInstance().GetDataTable(selectedTableName);
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MyDataGridView.CurrentCell != null)
            {
                DataGridViewCell cell = MyDataGridView.CurrentCell;

                // Create a record in the database if an element
                // is created in the DataGridView that does not exist
                if (MyDataGridView.Rows[cell.RowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    ITableEntity tableEntity = TableFactory.CreateTableEntity(cbTables.SelectedItem.ToString());
                    DatabaseManager.GetInstance().AddNewEntity(tableEntity);
                    MyDataGridView.Rows[cell.RowIndex].Cells[0].Value = cell.RowIndex + 1;
                }

                // Update a field in the database when trying to change it via DataGridView
                try
                {
                    var cell_value = cell.Value;
                    DatabaseManager.GetInstance().UpdateData(
                        cbTables.SelectedItem.ToString(),
                        MyDataGridView.Columns[cell.ColumnIndex].Name,
                        cell_value,
                        Convert.ToInt32(MyDataGridView.Rows[cell.RowIndex].Cells[0].Value)
                    );
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE constraint failed"))
                    {
                        MessageBox.Show("UNIQUE constraint failed\n" +
                            "It is impossible to change the field because the uniqueness \n" +
                            " of the values in the database is violated");
                        cell.Value = DBNull.Value;
                    }
                    else if (ex.Message.Contains("FOREIGN KEY constraint failed"))
                    {
                        MessageBox.Show("FOREIGN KEY\n" +
                            "The value cannot be set. \n" +
                            "The foreign key does not refer to the table. Erroneous index.");
                        cell.Value = DBNull.Value;
                    }
                }
            }
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyDataGridView.DataSource = DatabaseManager.GetInstance().GetDataTable(cbTables.SelectedItem.ToString());
            SetDesireWidthColumn(150);
        }
    }
}