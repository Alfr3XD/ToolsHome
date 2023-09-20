using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ToolsHome.Models;

namespace ToolsHome.Services
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DatabaseContext(string uri)
        {
            Connection = new SQLiteAsyncConnection(uri);

            Connection.CreateTableAsync<Tarea>().Wait();
        }

        public async Task<List<Tarea>> GetItemsAsync()
        {
            return await Connection.Table<Tarea>().ToListAsync();
        }

        public async Task<int> InsertItem(Tarea item)
        {
            return await Connection.InsertAsync(item);
        }
    }
}