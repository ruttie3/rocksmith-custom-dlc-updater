using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Rocksmith_Custom_DLC_Updater.Lib
{
    static class DB
    {
        private static SQLiteConnection _dbConnection;

        public static SQLiteConnection GetInstance()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteConnection("Data Source=updater.sqlite;Version=3;");
                _dbConnection.Open();
            }
            return _dbConnection;
        }

        public static void CloseConnection()
        {
            if (_dbConnection != null)
            {
                _dbConnection.Close();
            }
        }
    }
}
