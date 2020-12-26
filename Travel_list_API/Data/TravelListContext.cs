using Microsoft.EntityFrameworkCore;
using System;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class TravelListContext : DbContext
    {
        public DbSet<TravelList> TravelLists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Client> Clients { get; set; }

        public TravelListContext(DbContextOptions<TravelListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TravelList>()
                .HasMany(t => t.Items)
                .WithOne()
                .IsRequired();

            builder.Entity<TravelList>()
                .HasMany(t => t.Tasks)
                .WithOne()
                .IsRequired();

            builder.Entity<Client>()
                .HasMany(c => c.TravelLists)
                .WithOne()
                .IsRequired();

            builder.Entity<Client>().HasData(
                new Client() { Id = 1, Email = "client@gmail.com", FirstName = "Pog", LastName = "Champ", BirthDate = DateTime.Now },
                new Client() { Id = 2, Email = "client2@gmail.com", FirstName = "Ayaya", LastName = "Clap", BirthDate = DateTime.Now }
                );

            builder.Entity<TravelList>().HasData(
                new TravelList() { Id = 1, Name = "Test1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1 },
                new TravelList() { Id = 2, Name = "Test2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1 },
                new TravelList() { Id = 3, Name = "Test3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1 },
                new TravelList() { Id = 4, Name = "Test4", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 2 },
                new TravelList() { Id = 5, Name = "Test5", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 2 }
                );

            builder.Entity<Item>().HasData(
                new Item() { Id = 1, Name = "Item 1", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij, TravelListId = 1 },
                new Item() { Id = 2, Name = "Item 2", Added = true, Amount = 2, Category = Item.ItemCategory.Kledij, TravelListId = 1 },
                new Item() { Id = 3, Name = "Item 3", Added = true, Amount = 5, Category = Item.ItemCategory.Kledij, TravelListId = 2 },
                new Item() { Id = 4, Name = "Item 4", Added = false, Amount = 3, Category = Item.ItemCategory.Kledij, TravelListId = 2 },
                new Item() { Id = 5, Name = "Item 5", Added = false, Amount = 1, Category = Item.ItemCategory.Kledij, TravelListId = 3 },
                new Item() { Id = 6, Name = "Item 6", Added = true, Amount = 8, Category = Item.ItemCategory.Kledij, TravelListId = 4 },
                new Item() { Id = 7, Name = "Item 7", Added = false, Amount = 6, Category = Item.ItemCategory.Kledij, TravelListId = 4 },
                new Item(){ Id = 8, Name = "Item 8", Added = true, Amount = 9, Category = Item.ItemCategory.Kledij, TravelListId = 5 }
                );
        }
    }
}
