using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the chores backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class ChoreRepository : IChoreRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public ChoreRepository(Context db) => _db = db;
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new chore if the chore does not exist, updates the 
        /// existing chore otherwise.
        /// </summary>
        public async Task<Chore> UpsertChoreAsync(int tripId, Chore chore)
        {
            var current = await _db.Chores.SingleOrDefaultAsync(c => c.Id == chore.Id);
            if (current == null)
            {
                var trip = await GetTrip(tripId);
                trip.AddChore(chore);
                _db.Trips.Update(trip);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(chore);
            }
            await _db.SaveChangesAsync();
            return chore;
        }

        /// <summary>
        /// Deletes a chore.
        /// </summary>
        public async Task<bool> DeleteChoreAsync(int tripId, int choreId)
        {
            var trip = await GetTrip(tripId);
            trip.RemoveChore(trip.Chores.Single(c => c.Id == choreId));
            _db.Trips.Update(trip);
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Return the trip associated with the given id.
        /// </summary>
        private async Task<Trip> GetTrip(int id)
        {
            return await _db.Trips
                .Include(t => t.Chores)
                .SingleAsync(t => t.Id == id);
        } 
        #endregion
    }
}
