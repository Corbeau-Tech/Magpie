using System;
using MagpieProject.Database;
using MagpieProject.Interfaces;
using MagpieProject.iOS.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBManagerClass))]
namespace MagpieProject.iOS.DependencyServices
{
    public class DBManagerClass : IIDBManager
    {
        internal DBManager instance;

        public DBManagerClass()
        {
        }

        void IIDBManager.DbConnection(DBManager manager)
        {
            instance = manager;
        }
    }
}
