using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the trips backend.
    /// </summary>
    public interface ITripRepository
    {
        /// <summary>
        /// Returns all trips. 
        /// </summary>
        Task<IEnumerable<Trip>> GetTripsAsync(string email);

        /// <summary>
        /// Returns the trip with the given id. 
        /// </summary>
        Task<Trip> GetTripAsync(string email, int id);

        /// <summary>
        /// Adds a new trip if the trip does not exist, updates the 
        /// existing trip otherwise.
        /// </summary>
        Task<Trip> UpsertTripAsync(string email, Trip trip);

        /// <summary>
        /// Deletes a trip.
        /// </summary>
        Task<bool> DeleteTripAsync(string email, int id);
    }
}
