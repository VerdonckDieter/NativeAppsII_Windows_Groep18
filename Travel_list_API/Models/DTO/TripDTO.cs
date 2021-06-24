using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents a trip DTO.
    /// </summary>
    public class TripDTO
    {
        /// <summary>
        /// Gets or sets the trip DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the trip DTO's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the trip DTO's location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the trip DTO's start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the trip DTO's end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the trip DTO's chores.
        /// </summary>
        public List<Chore> Chores { get; set; } = new List<Chore>();

        /// <summary>
        /// Gets or sets the trip DTO's categories.
        /// </summary>
        public List<Category> Categories { get; set; } = new List<Category>();

        /// <summary>
        /// Gets or sets the trip DTO's itineraries.
        /// </summary>
        public List<Itinerary> Itineraries { get; set; } = new List<Itinerary>();
    }
}
