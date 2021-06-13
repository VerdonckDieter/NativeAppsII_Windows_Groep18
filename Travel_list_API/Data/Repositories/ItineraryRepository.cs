using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the itineraries backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class ItineraryRepository : IItineraryRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public ItineraryRepository(Context db) => _db = db;
        #endregion

        #region Methods
        /// <summary>
        /// Returns all itineraries associated with the given tripId. 
        /// </summary>
        public async Task<IEnumerable<Itinerary>> GetItinerariesAsync(int tripId) => (await GetTrip(tripId, false)).Itineraries;

        /// <summary>
        /// Returns the itinerary with the given id associated with the given tripId. 
        /// </summary>
        public async Task<Itinerary> GetItineraryAsync(int tripId, int itineraryId) => (await GetTrip(tripId, false)).Itineraries.Single(t => t.Id == itineraryId);

        /// <summary>
        /// Adds a new itinerary if the itinerary does not exist, updates the 
        /// existing itinerary otherwise.
        /// </summary>
        public async Task<Itinerary> UpsertItineraryAsync(int tripId, Itinerary itinerary)
        {
            var current = await _db.Itineraries.SingleOrDefaultAsync(c => c.Id == itinerary.Id);
            if (current == null)
            {
                var trip = await GetTrip(tripId, true);
                trip.AddItinerary(itinerary);
                _db.Trips.Update(trip);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(itinerary);
            }
            await _db.SaveChangesAsync();
            return itinerary;
        }

        /// <summary>
        /// Deletes an itinerary.
        /// </summary>
        public async Task<bool> DeleteItineraryAsync(int tripId, int itineraryId)
        {
            var trip = await GetTrip(tripId, true);
            trip.RemoveItinerary(trip.Itineraries.Single(c => c.Id == itineraryId));
            _db.Trips.Update(trip);
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Return the trip associated with the given id. 
        /// </summary>
        private async Task<Trip> GetTrip(int id, bool tracking)
        {
            return tracking ?
                await _db.Trips
                .Include(t => t.Itineraries)
                .SingleAsync(t => t.Id == id) :
                await _db.Trips
                .Include(t => t.Itineraries)
                .AsNoTracking()
                .SingleAsync(t => t.Id == id);
        } 
        #endregion
    }
}
