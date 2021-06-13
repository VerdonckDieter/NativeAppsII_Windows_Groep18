using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the itineraries backend.
    /// </summary>
    public interface IItineraryRepository
    {
        /// <summary>
        /// Returns all itineraries associated with the given tripId. 
        /// </summary>
        Task<IEnumerable<Itinerary>> GetItinerariesAsync(int tripId);

        /// <summary>
        /// Returns the itinerary with the given id associated with the given tripId. 
        /// </summary>
        Task<Itinerary> GetItineraryAsync(int tripId, int itineraryId);

        /// <summary>
        /// Adds a new itinerary if the itinerary does not exist, updates the 
        /// existing itinerary otherwise.
        /// </summary>
        Task<Itinerary> UpsertItineraryAsync(int tripId, Itinerary itinerary);

        /// <summary>
        /// Deletes an itinerary.
        /// </summary>
        Task<bool> DeleteItineraryAsync(int tripId, int itineraryId);
    }
}
