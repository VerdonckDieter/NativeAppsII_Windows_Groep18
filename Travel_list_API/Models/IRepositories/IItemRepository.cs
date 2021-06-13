using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the items backend.
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Adds a new item if the item does not exist, updates the 
        /// existing item otherwise.
        /// </summary>
        Task<Item> UpsertItemAsync(int categoryId, Item item);

        /// <summary>
        /// Deletes an item.
        /// </summary>
        Task<bool> DeleteItemAsync(int categoryId, int itemId);
    }
}
