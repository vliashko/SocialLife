using SL.XamarinRealize.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SL.XamarinRealize.Repositories
{
    public class EventRepositoryAsync
    {
        
        readonly SQLiteAsyncConnection database;
        public EventRepositoryAsync(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Event>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Event>();
        }
        public async Task<List<Event>> GetItemsAsync()
        {
            return await database.Table<Event>().ToListAsync();
        }
        public async Task<Event> GetItemAsync(int id)
        {
            return await database.GetAsync<Event>(id);
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            return await database.DeleteAsync<Event>(id);
        }
        public async Task<int> SaveItemAsync(Event item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
