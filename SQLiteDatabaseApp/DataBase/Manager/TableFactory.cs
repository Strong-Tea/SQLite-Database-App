using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDatabaseApp.DataBase.Manager
{
    internal class TableFactory
    {
        public static ITableEntity CreateTableEntity(string className)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == className);
            if (type != null && typeof(ITableEntity).IsAssignableFrom(type))
            {
                return (ITableEntity)Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
