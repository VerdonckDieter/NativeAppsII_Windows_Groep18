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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
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

            builder.Entity<TravelList>()
                .HasMany(t => t.Categories)
                .WithOne()
                .IsRequired();

            builder.Entity<TravelList>()
                .HasOne(t => t.Itinerary)
                .WithOne()
                .HasForeignKey<Itinerary>(i => i.TravelListId)
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
                new TravelList() { Id = 1, Name = "Spanje", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1},
                new TravelList() { Id = 2, Name = "Frankrijk", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1},
                new TravelList() { Id = 3, Name = "Nederland", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 1 },
                new TravelList() { Id = 4, Name = "Duitsland", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 2 },
                new TravelList() { Id = 5, Name = "Noorwegen", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), ClientId = 2 }
                );

            Itinerary une = new Itinerary() { Id = 1, TravelListId = 1, StartLatitude = 51.054340, StartLongitude = 3.717424, EndLatitude = 41.385063, EndLongitude = 2.173404 };
            Itinerary deux = new Itinerary() { Id = 2, TravelListId = 2, StartLatitude = 51.054340, StartLongitude = 3.717424, EndLatitude = 48.856613, EndLongitude = 2.352222 };
            Itinerary trois = new Itinerary() { Id = 3, TravelListId = 3, StartLatitude = 51.054340, StartLongitude = 3.717424, EndLatitude = 52.370216, EndLongitude = 4.895168 };

            builder.Entity<Itinerary>().HasData(
                une, deux, trois
                );

            Category one = new Category() { Id = 1, Name = "Opmaak", TravelListId = 1 };
            Category two = new Category() { Id = 2, Name = "Technologie", TravelListId = 1 };
            Category three = new Category() { Id = 3, Name = "Bad", TravelListId = 1 };
            Category four = new Category() { Id = 4, Name = "Kledij", TravelListId = 1 };
            Category five = new Category() { Id = 5, Name = "Opmaak", TravelListId = 2 };
            Category six = new Category() { Id = 6, Name = "Technologie", TravelListId = 2 };
            Category seven = new Category() { Id = 7, Name = "Bad", TravelListId = 2 };
            Category eight = new Category() { Id = 8, Name = "Kledij", TravelListId = 2 };

            builder.Entity<Category>().HasData(
                one,
                two,
                three,
                four,
                five,
                six,
                seven,
                eight
                );

            builder.Entity<Item>().HasData(
                new Item() { Id = 1, Name = "Kam", Added = false, Amount = 1, Category = "Opmaak", TravelListId = 1 },
                new Item() { Id = 2, Name = "Laptop", Added = true, Amount = 2, Category = "Technologie", TravelListId = 1 },
                new Item() { Id = 3, Name = "Handdoek", Added = true, Amount = 5, Category = "Bad", TravelListId = 2 },
                new Item() { Id = 4, Name = "Tandenborstel", Added = false, Amount = 3, Category = "Bad", TravelListId = 2 },
                new Item() { Id = 5, Name = "Batterij", Added = false, Amount = 1, Category = "Technologie", TravelListId = 3 },
                new Item() { Id = 6, Name = "Shampoo", Added = true, Amount = 8, Category = "Bad", TravelListId = 4 },
                new Item() { Id = 7, Name = "Broek", Added = false, Amount = 6, Category = "Kledij", TravelListId = 4 },
                new Item() { Id = 8, Name = "Sjaal", Added = true, Amount = 9, Category = "Kledij", TravelListId = 5 }
                );
        }
    }
}
