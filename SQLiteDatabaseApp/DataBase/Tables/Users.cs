using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDatabaseApp.DataBase.Manager;

namespace SQLiteDatabaseApp.DataBase.Tables
{
    internal class Users : ITableEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
