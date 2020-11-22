using SL.XamarinRealize.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SL.XamarinRealize.Repositories
{
    public class ItemRepositoryAsync
    {
        readonly SQLiteAsyncConnection database;
        public ItemRepositoryAsync(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Item>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Item>();
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            return await database.Table<Item>().ToListAsync();
        }
        public async Task<Item> GetItemAsync(int id)
        {
            return await database.GetAsync<Item>(id);
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            return await database.DeleteAsync<Item>(id);
        }
        public async Task<int> SaveItemAsync(Item item)
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
