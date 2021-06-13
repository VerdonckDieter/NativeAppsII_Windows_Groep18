using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    /// <summary>
    /// Entity Framework Core DbContext for TravelListApp.
    /// </summary>
    public class Context : IdentityDbContext
    {
        /// <summary>
        /// Creates a new DbContext.
        /// </summary>
        public Context(DbContextOptions<Context> options) : base(options) { }

        /// <summary>
        /// Gets the trips DbSet.
        /// </summary>
        public DbSet<Trip> Trips { get; set; }

        /// <summary>
        /// Gets the items DbSet.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets the chores DbSet.
        /// </summary>
        public DbSet<Chore> Chores { get; set; }

        /// <summary>
        /// Gets the categories DbSet.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets the itineraries DbSet.
        /// </summary>
        public DbSet<Itinerary> Itineraries { get; set; }

        /// <summary>
        /// Gets the users DbSet.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
