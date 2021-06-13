using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

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
        /// <summary>
        /// Returns all trips. 
        /// </summary>
        public async Task<IEnumerable<Trip>> GetTripsAsync(string email) => (await GetUser(email, false)).Trips;

        /// <summary>
        /// Returns the trip with the given id. 
        /// </summary>
        public async Task<Trip> GetTripAsync(string email, int id) => (await GetUser(email, false)).Trips.SingleOrDefault(t => t.Id == id);

        /// <summary>
        /// Adds a new trip if the trip does not exist, updates the 
        /// existing trip otherwise.
        /// </summary>
        public async Task<Trip> UpsertTripAsync(string email, Trip trip)
        {
            var current = await GetTripAsync(email, trip.Id);
            if (current == null)
            {
                var user = await GetUser(email, true);
                user.AddTrip(trip);
                _db.Users.Update(user);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(trip);
            }
            await _db.SaveChangesAsync();
            return trip;
        }

        /// <summary>
        /// Deletes a trip.
        /// </summary>
        public async Task<bool> DeleteTripAsync(string email, int id)
        {
            var user = await GetUser(email, true);
            user.RemoveTrip(user.Trips.Single(t => t.Id == id));
            _db.Users.Update(user);
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Return the user associated with the given email.
        /// </summary>
        private async Task<User> GetUser(string email, bool tracking)
        {
            return tracking ?
                await _db.Users
                .Include(u => u.Trips).ThenInclude(t => t.Chores)
                .Include(u => u.Trips).ThenInclude(t => t.Categories).ThenInclude(c => c.Items)
                .Include(u => u.Trips).ThenInclude(t => t.Itineraries)
                .SingleAsync(s => s.Email == email) :
                await _db.Users
                .Include(u => u.Trips).ThenInclude(t => t.Chores)
                .Include(u => u.Trips).ThenInclude(t => t.Categories).ThenInclude(c => c.Items)
                .Include(u => u.Trips).ThenInclude(t => t.Itineraries)
                .AsNoTracking()
                .SingleAsync(s => s.Email == email);
        } 
        #endregion
    }
}
