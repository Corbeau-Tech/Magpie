using System;
using MagpieProject.Database;
using MagpieProject.Droid.DependencyServices;
using MagpieProject.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBManagerClass))]

namespace MagpieProject.Droid.DependencyServices
{
    public class DBManagerClass : IIDBManager
    {
        public static DBManager instance = null;

        public DBManagerClass()
        {
        }

        void IIDBManager.DbConnection(DBManager manager)
        {
            instance = manager;
        }
    }
}
