using System;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class TravelListDataInit
    {
        private readonly TravelListContext _dbContext;

        public TravelListDataInit(TravelListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                SeedData();
            }
        }

        private void SeedData()
        {
            TravelList travelList = new TravelList() { Name = "Spanje", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            _dbContext.SaveChanges();
            Item item = new Item { Name = "Item 1", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            item = new Item { Name = "Item 2", Added = true, Amount = 2, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            _dbContext.SaveChanges();

            travelList = new TravelList() { Name = "Frankrijk", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            _dbContext.SaveChanges();
            item = new Item { Name = "Item 3", Added = true, Amount = 5, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            item = new Item { Name = "Item 4", Added = false, Amount = 3, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            _dbContext.SaveChanges();

            travelList = new TravelList() { Name = "Nederland", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            _dbContext.SaveChanges();
            item = new Item { Name = "Item 5", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            item = new Item { Name = "Item 6", Added = true, Amount = 8, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            _dbContext.SaveChanges();

            travelList = new TravelList() { Name = "Italië", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            _dbContext.SaveChanges();
            item = new Item { Name = "Item 7", Added = false, Amount = 6, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            item = new Item { Name = "Item 8", Added = true, Amount = 9, Category = Item.ItemCategory.Kledij };
            travelList.AddItem(item);
            _dbContext.SaveChanges();
        }
    }
}
