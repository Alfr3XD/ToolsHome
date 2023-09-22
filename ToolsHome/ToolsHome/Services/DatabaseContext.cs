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
                    // El registro no existe
                    return 0; // O algún otro valor que indique que no se pudo actualizar
                }
            }
            catch
            {
                // Manejo de errores, puedes agregar el código adecuado aquí
                return 0;
            }
        }
    }
}