using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace MagpieProject.Helper
{
    public class SqlHelper
    {
        private static readonly object locker = new object();
        private readonly SQLiteConnection database;

        public SqlHelper()
        {
            database = GetConnection();
            //database.CreateTable<SearchLocalDatabaseModel>();
        }

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlitConnection;
            string sqliteFilename = "MagpieDB.db3";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            sqlitConnection = new SQLiteConnection(path);
            return sqlitConnection;
        }

      
    }
}
