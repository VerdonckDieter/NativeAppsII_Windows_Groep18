using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class DataInit
    {
        #region Fields
        private readonly Context _db;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion

        #region Constructors
        public DataInit(Context db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task InitializeData()
        {
            await _db.Database.EnsureDeletedAsync();
            if (await _db.Database.EnsureCreatedAsync())
            {
                var user = new User { Email = "client@gmail.com", FirstName = "Dieter", LastName = "D" };
                await _db.Users.AddAsync(user);

                var trip = new Trip { Name = "Travel to Paris", Location = "Paris", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
                user.Trips.Add(trip);

                var category = new Category { Name = "Kitchen" };
                var chore = new Chore { Name = "Get kitchen knife" };
                var itinerary = new Itinerary { StartLatitude = 1.00, StartLongitude = 2.00, EndLatitude = 3.00, EndLongitude = 4.00 };

                trip.Categories.Add(category);
                trip.Chores.Add(chore);
                trip.Itineraries.Add(itinerary);

                var item = new Item { Name = "Knife", Amount = 2, Added = false };
                category.AddItem(item);

                user = new User { Email = "client2@gmail.com", FirstName = "Dylan", LastName = "D" };
                await _db.Users.AddAsync(user);

                trip = new Trip { Name = "Travel to London", Location = "London", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2) };
                user.AddTrip(trip);

                category = new Category { Name = "Sports" };
                chore = new Chore { Name = "Get football" };
                itinerary = new Itinerary { StartLatitude = 5.00, StartLongitude = 6.00, EndLatitude = 7.00, EndLongitude = 8.00 };

                trip.Categories.Add(category);
                trip.Chores.Add(chore);
                trip.Itineraries.Add(itinerary);

                item = new Item { Name = "Football", Amount = 1, Added = true };
                category.AddItem(item);

                user = new User { Email = "client3@gmail.com", FirstName = "Thibault", LastName = "D" };
                await _db.Users.AddAsync(user);

                trip = new Trip { Name = "Travel to Milan", Location = "Milan", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3) };
                user.AddTrip(trip);

                category = new Category { Name = "Electronics" };
                chore = new Chore { Name = "Get phone charger" };
                itinerary = new Itinerary { StartLatitude = 9.00, StartLongitude = 10.00, EndLatitude = 11.00, EndLongitude = 12.00 };

                trip.Categories.Add(category);
                trip.Chores.Add(chore);
                trip.Itineraries.Add(itinerary);

                item = new Item { Name = "Phone", Amount = 3, Added = false };
                category.AddItem(item);

                await _db.SaveChangesAsync();

                await InitializeUsers();
            }
        }

        private async Task InitializeUsers()
        {
            foreach (var user in await _db.Users.ToListAsync())
            {
                var identityUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
                await _userManager.CreateAsync(identityUser, "P@ssword1111");
                await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Role, "user"));
            }
        }
        #endregion
    }
}
