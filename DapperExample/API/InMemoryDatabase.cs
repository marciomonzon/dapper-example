using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace API
{
    public class InMemoryDatabase
    {
        private readonly IDbConnection _dbConnection;

        public InMemoryDatabase()
        {
            _dbConnection = new SqliteConnection("Data Source=:memory:");
            _dbConnection.Open();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var createTableQuery = @"
            CREATE TABLE Customer (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL
            );";

            _dbConnection.Execute(createTableQuery);
        }

        public IDbConnection Connection => _dbConnection;
    }
}
