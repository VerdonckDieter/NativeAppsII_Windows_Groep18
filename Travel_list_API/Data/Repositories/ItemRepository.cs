using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the items backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class ItemRepository : IItemRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public ItemRepository(Context db) => _db = db;
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new item if the item does not exist, updates the 
        /// existing item otherwise.
        /// </summary>
        public async Task<Item> UpsertItemAsync(int categoryId, Item item)
        {
            var current = await _db.Items.SingleOrDefaultAsync(i => i.Id == item.Id);
            if (current == null)
            {
                var category = await GetCategory(categoryId);
                category.AddItem(item);
                _db.Categories.Update(category);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(item);
            }
            await _db.SaveChangesAsync();
            return item;
        }

        /// <summary>
        /// Deletes an item.
        /// </summary>
        public async Task<bool> DeleteItemAsync(int categoryId, int itemId)
        {
            var category = await GetCategory(categoryId);
            category.RemoveItem(category.Items.Single(i => i.Id == itemId));
            _db.Categories.Update(category);
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Return the category associated with the given id.
        /// </summary>
        private async Task<Category> GetCategory(int id)
        {
            return await _db.Categories
                .Include(c => c.Items)
                .SingleAsync(c => c.CategoryId == id);
        } 
        #endregion
    }
}
