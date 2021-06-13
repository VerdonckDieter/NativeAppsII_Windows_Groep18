using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with itinerary data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Policy = "User")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryRepository _itineraryRepository;

        public ItineraryController(IItineraryRepository itineraryRepository) => _itineraryRepository = itineraryRepository;

        /// <summary>
        /// Gets all itineraries of a specific trip.
        /// </summary>
        [HttpGet("{tripId}")]
        public async Task<ActionResult<IEnumerable<Itinerary>>> GetItinerariesAsync(int tripId)
        {
            try
            {
                return Ok(await _itineraryRepository.GetItinerariesAsync(tripId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets the itinerary with the given itinerary id of a specific trip.
        /// </summary>
        [HttpGet("{tripId}/{itineraryId}")]
        public async Task<ActionResult<Itinerary>> GetTripAsync(int tripId, int itineraryId)
        {
            try
            {
                return Ok(await _itineraryRepository.GetItineraryAsync(tripId, itineraryId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new itinerary or updates an existing one.
        /// </summary>
        [HttpPost("{tripId}")]
        public async Task<ActionResult> PostItinerary(int tripId, ItineraryDTO itineraryDTO)
        {
            var itinerary = new Itinerary()
            {
                Id = itineraryDTO.Id,
                StartLatitude = itineraryDTO.StartLatitude,
                StartLongitude = itineraryDTO.StartLongitude,
                EndLatitude = itineraryDTO.EndLatitude,
                EndLongitude = itineraryDTO.EndLongitude
            };
            return Ok(await _itineraryRepository.UpsertItineraryAsync(tripId, itinerary));
        }

        /// <summary>
        /// Deletes an itinerary.
        /// </summary>
        [HttpDelete("{tripId}/{itineraryId}")]
        public async Task<ActionResult> DeleteItinerary(int tripId, int itineraryId)
        {
            return Ok(await _itineraryRepository.DeleteItineraryAsync(tripId, itineraryId));
        }
    }
}
