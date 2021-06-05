using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Data.Repositories.IRepositories;
using Travel_list_API.Models;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the trips backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class TripRepository : ITripRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public TripRepository(Context db) => _db = db;
        #endregion

        #region Methods
        public async Task<IEnumerable<Trip>> GetTripsAsync(string email) => (await GetUser(email, false)).Trips;

        public async Task<Trip> GetTripAsync(string email, int id) => (await GetUser(email, false)).Trips.Single(t => t.Id == id);

        public async Task<Trip> UpsertTripAsync(string email, Trip trip)
        {
            if (await GetTripAsync(email, trip.Id) == null)
            {
                var user = await GetUser(email, true);
                user.AddTrip(trip);
                _db.Users.Update(user);
            }
            else
            {
                _db.Update(trip);
            }
            await _db.SaveChangesAsync();
            return trip;
        }

        public async Task DeleteTripAsync(string email, int id)
        {
            var user = await GetUser(email, true);
            user.RemoveTrip(user.Trips.Single(t => t.Id == id));
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        private async Task<User> GetUser(string email, bool tracking)
        {
            return tracking ?
                await _db.Users
                .Include(u => u.Trips).ThenInclude(t => t.Items)
                .Include(u => u.Trips).ThenInclude(t => t.Chores)
                .Include(u => u.Trips).ThenInclude(t => t.Categories)
                .Include(u => u.Trips).ThenInclude(t => t.Itineraries)
                .SingleAsync(s => s.Email == email) :
                await _db.Users
                .Include(u => u.Trips).ThenInclude(t => t.Items)
                .Include(u => u.Trips).ThenInclude(t => t.Chores)
                .Include(u => u.Trips).ThenInclude(t => t.Categories)
                .Include(u => u.Trips).ThenInclude(t => t.Itineraries)
                .AsNoTracking()
                .SingleAsync(s => s.Email == email);
        } 
        #endregion
    }
}
