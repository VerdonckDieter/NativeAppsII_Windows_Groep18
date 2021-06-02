using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems(int travelListId);
        Item GetItemById(int travelListId, int itemId);
        void AddItem(int travelListId, Item item);
        void UpdateItem(Item item);
        void DeleteItem(int travelListId, Item item);
        void SaveChanges();
    }
}
