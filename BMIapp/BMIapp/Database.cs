using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BMIapp
{
    public class Database
    {
        static SQLiteAsyncConnection _db;

        public Database(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<BMIResult>().Wait();
        }
        public Task<List<BMIResult>> GetAll()
        {
            return _db.Table<BMIResult>().ToListAsync();
        }
        public Task<int> Add(BMIResult result)
        {
            return _db.InsertAsync(result);
        }
    }
}
