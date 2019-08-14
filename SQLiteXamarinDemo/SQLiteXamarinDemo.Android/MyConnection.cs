using SQLite;
using System.IO;
using SQLiteXamarinDemo.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(MyConnection))]

namespace SQLiteXamarinDemo.Droid
{
    class MyConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "ProductsDB.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}