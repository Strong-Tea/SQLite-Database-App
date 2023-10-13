using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDatabaseApp.DataBase.Manager;

namespace SQLiteDatabaseApp.DataBase.Tables
{
    internal class Modes : ITableEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxBottleNumber { get; set; }
        public int MaxUsedTips { get; set; }
    }
}
