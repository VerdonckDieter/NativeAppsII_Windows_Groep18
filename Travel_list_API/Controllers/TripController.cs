using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with trip data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Policy = "User")]
    public class TripController : ControllerBase
    {
        #region Fields
        private readonly ITripRepository _tripRepository;
        #endregion

        #region Constructors
        public TripController(ITripRepository tripRepository) => _tripRepository = tripRepository;
        #endregion

        #region Methods
        /// <summary>
        /// Gets all trips of the logged in user.
        /// </summary>
        [HttpGet("GetTrips")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTripsAsync()
        {
            try
            {
                return Ok(await _tripRepository.GetTripsAsync(User.Identity.Name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets the trip with the given id of the logged in user.
        /// </summary>
        [HttpGet("{tripId}")]
        public async Task<ActionResult<Trip>> GetTripAsync(int tripId)
        {
            try
            {
                return Ok(await _tripRepository.GetTripAsync(User.Identity.Name, tripId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new trip or updates an existing one.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> PostTrip(TripDTO tripDTO)
        {
            var trip = new Trip()
            {
                Id = tripDTO.Id,
                Name = tripDTO.Name,
                Location = tripDTO.Location,
                StartDate = tripDTO.StartDate,
                EndDate = tripDTO.EndDate,
                Chores = tripDTO.Chores,
                Categories = tripDTO.Categories,
                Itineraries = tripDTO.Itineraries
            };
            return Ok(await _tripRepository.UpsertTripAsync(User.Identity.Name, trip));
        }

        /// <summary>
        /// Deletes a trip.
        /// </summary>
        [HttpDelete("{tripId}")]
        public async Task<ActionResult> DeleteTrip(int tripId)
        {
            return Ok(await _tripRepository.DeleteTripAsync(User.Identity.Name, tripId));
        } 
        #endregion
    }
}
