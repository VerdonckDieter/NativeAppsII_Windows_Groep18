//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using Travel_list_API.Models;
//using Travel_list_API.Models.IRepositories;

//namespace Travel_list_API.Data.Repositories
//{
//    public class ItemRepository : IItemRepository
//    {
//        private readonly Context _dbContext;
//        private readonly DbSet<Trip> _travelLists;
//        private readonly DbSet<Item> _items;
//        public ItemRepository(Context dbContext)
//        {
//            _dbContext = dbContext;
//            _travelLists = dbContext.TravelLists;
//            _items = dbContext.Items;
//        }

//        public void AddItem(int travelListId, Item item)
//        {
//            Trip travelList = GetTravelListById(travelListId, true);
//            travelList.AddItem(item);
//            _travelLists.Update(travelList);
//        }

//        public void DeleteItem(int travelListId, Item item)
//        {
//            Trip travelList = GetTravelListById(travelListId, true);
//            travelList.RemoveItem(item);
//            _travelLists.Update(travelList);
//        }

//        public Item GetItemById(int travelListId, int itemId)
//        {
//            return GetTravelListById(travelListId, false).Items.Single(i => i.Id == itemId);
//        }

//        public IEnumerable<Item> GetItems(int travelListId)
//        {
//            return GetTravelListById(travelListId, false).Items;
//        }

//        public void UpdateItem(Item item)
//        {
//            _items.Update(item);
//        }

//        public void SaveChanges()
//        {
//            _dbContext.SaveChanges();
//        }

//        private Trip GetTravelListById(int id, bool tracking)
//        {
//            return tracking ? _travelLists.Include(c => c.Items).First(t => t.Id == id) :
//                _travelLists.Include(c => c.Items).AsNoTracking().First(t => t.Id == id);
//        }
//    }
//}
