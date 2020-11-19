using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class TravelListContext : DbContext
    {
        public DbSet<TravelList> TravelLists { get; set; }


        public TravelListContext(DbContextOptions<TravelListContext> options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //necessary for supporting the Add-Migration command from Pack Man Console
            var connectionstring = @"Server=(localdb)\MSSQLLocalDB;Database=TravelListDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionstring);
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.Entity<TravelList>()
                .HasMany(t => t.Items)
                .WithOne()
                .IsRequired()
                .HasForeignKey("TravelListId");

            builder.Entity<TravelList>().HasData(
                new TravelList() { Id = 1, Name = "Test1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                new TravelList() { Id = 2, Name = "Test2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                new TravelList() { Id = 3, Name = "Test3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                new TravelList() { Id = 4, Name = "Test4", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                new TravelList() { Id = 5, Name = "Test5", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) }
                );

            builder.Entity<Item>().HasData(
                new { Id = 1, Name = "Item 1", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij, TravelListId = 1 },
                new { Id = 2, Name = "Item 2", Added = true, Amount = 2, Category = Item.ItemCategory.Kledij, TravelListId = 1 },
                new { Id = 3, Name = "Item 3", Added = true, Amount = 5, Category = Item.ItemCategory.Kledij, TravelListId = 2 },
                new { Id = 4, Name = "Item 4", Added = false, Amount = 3, Category = Item.ItemCategory.Kledij, TravelListId = 2 },
                new { Id = 5, Name = "Item 5", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij, TravelListId = 3 },
                new { Id = 6, Name = "Item 6", Added = true, Amount = 8, Category = Item.ItemCategory.Kledij, TravelListId = 4 },
                new { Id = 7, Name = "Item 7", Added = false, Amount = 6, Category = Item.ItemCategory.Kledij, TravelListId = 4 },
                new { Id = 8, Name = "Item 8", Added = true, Amount = 9, Category = Item.ItemCategory.Kledij, TravelListId = 5 }
                );
        }
    }
}
