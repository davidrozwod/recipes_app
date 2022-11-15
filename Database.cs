using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace RecipesApp
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipes>().Wait();
        }

        public Task<List<Recipes>> GetRecipesAsync()
        {
            return _database.Table<Recipes>().ToListAsync();
        }

        public Task<Recipes> GetRecipeAsync(int id)
        {
            return _database.Table<Recipes>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipesAsync(Recipes item)
        {
            if (item.ID != 0)   
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteEmployeeAsync(Recipes item)
        {
            return _database.DeleteAsync(item);
        }
    }
}