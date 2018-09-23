using System;
using System.Collections.Generic;
using System.Text;

namespace CL_Acceso.Clases
{
    public class DatabaseHelper
    {
        public static bool Insertar<T>(ref T data, string ruta_db)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(ruta_db))
            {
                connection.CreateTable<T>();
                var result = connection.Insert(data);

                if(result!=0)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Viaje> LeerDatos(string ruta_db)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(ruta_db))
            {
                return connection.Table<Viaje>().ToList();
            }
        }
    }
}
