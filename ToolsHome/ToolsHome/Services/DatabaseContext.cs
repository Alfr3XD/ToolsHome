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

            Connection.CreateTableAsync<Tarea>().Wait();  // Table Tareas
            Connection.CreateTableAsync<Gasto>().Wait(); // Table Gastos
        }

        public async Task<List<Gasto>> GetGastosAsync()
        {
            return await Connection.Table<Gasto>().ToListAsync();
        }

        public async Task<int> InsertGastoAsync(Gasto item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<int> DeleteGastoAsync(Gasto item)
        {
            return await Connection.DeleteAsync(item);
        }
        public async Task<int> UpdateGasto(Gasto updatedItem)
        {
            try
            {
                var FindedItem = await Connection.FindAsync<Gasto>(updatedItem.Id);

                if (FindedItem != null)
                {
                    FindedItem.Description = updatedItem.Description;
                    FindedItem.Category = updatedItem.Category;
                    FindedItem.Date = updatedItem.Date;
                    FindedItem.Amount = updatedItem.Amount; 
                    FindedItem.State = updatedItem.State;

                    await Connection.UpdateAsync(FindedItem);

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }


        public async Task<List<Tarea>> GetItemsAsync()
        {
            return await Connection.Table<Tarea>().ToListAsync();
        }

        public async Task<int> InsertItem(Tarea item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<int> DeleteTaks(int id)
        {
            return await Connection.DeleteAsync<Tarea>(id);
        }

        public async Task<int> UpdateTaks(Tarea updatedTarea)
        {
            try
            {
                var existingTarea = await Connection.FindAsync<Tarea>(updatedTarea.Id);

                if (existingTarea != null)
                {
                    existingTarea.Description = updatedTarea.Description;
                    existingTarea.State = updatedTarea.State;
                    existingTarea.Timestamp = updatedTarea.Timestamp;

                    await Connection.UpdateAsync(existingTarea);

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}