using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDatabaseApp.DataBase.Manager;

namespace SQLiteDatabaseApp.DataBase.Tables
{
    internal class Steps : ITableEntity
    {
        public int ID { get; set; }
        public int? ModeId { get; set; }
        public int Timer { get; set; }
        public string Destination { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }
    }
}
