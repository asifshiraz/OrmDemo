using OrmDemo.Interfaces;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace OrmDemo.Classes
{
    public class SqliteConnectionFactory : IConnectionFactory
    {
        private const string DbFileName = "Sqlite.OrmDemo";
        static void EnsureDatabase()
        {
            if (!File.Exists(DbFileName))
            {
                SQLiteConnection.CreateFile(DbFileName);
            }
        }

        public IDbConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFileName);
        }

    }
}
