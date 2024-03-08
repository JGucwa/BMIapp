using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace BMIapp
{
    public class Database
    {
        /*
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
        }*/
        static string path;

        public Database(string dbPath)
        {
            path = dbPath;
        }
        public List<BMIResult> GetAll()
        {
            if(File.Exists(path))
            {
                List<string> results = File.ReadAllLines(path).ToList();
                List<BMIResult> BMIresults = new List<BMIResult>();

                foreach (var item in results)
                {
                    string[] entries = item.Split(';');

                    if (entries.Length == 7)
                    {
                        BMIResult tmpResult = new BMIResult();
                        tmpResult.Title = entries[0];
                        tmpResult.Date = DateTime.Parse(entries[1]);
                        tmpResult.Weight = float.Parse(entries[2]);
                        tmpResult.Height = float.Parse(entries[3]);
                        tmpResult.Gender = entries[4];
                        tmpResult.BMI = float.Parse(entries[5]);
                        tmpResult.Type = entries[6];

                        BMIresults.Add(tmpResult);
                    }
                }
                return BMIresults;
            }
            else
            {
                File.WriteAllLines(path, new List<string>());
                return new List<BMIResult>();
            }
            

        }
        public void Add(BMIResult result)
        {
            List<BMIResult> tmp = GetAll();
            tmp.Add(result);
            WriteToFile(tmp);
        }
        public static void WriteToFile(List<BMIResult> results)
        {
            List<string> output = new List<string>();
            foreach (var result in results)
            {
                string line = $"{result.Title};{result.Date};{result.Weight};{result.Height};{result.Gender};{result.BMI};{result.Type}";
                output.Add(line);
            }
            File.WriteAllLines(path, output);
        }
        public void Remove(BMIResult result)
        {
            List<BMIResult> tmp = GetAll();
            for(int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].Title == result.Title)
                {
                    tmp.RemoveAt(i);
                }
            }
            
            WriteToFile(tmp);
        }
    }
}
