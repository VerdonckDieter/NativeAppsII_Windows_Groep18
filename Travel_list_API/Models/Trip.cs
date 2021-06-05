using System;
using System.Collections.Generic;

namespace Travel_list_API.Models
{
    /// <summary>
    /// Represents a trip.
    /// </summary>
    public class Trip
    {
        #region Properties
        /// <summary>
        /// Gets or sets the trip's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the trip's
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the trip's start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the trip's end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the trip's items.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the trip's chores.
        /// </summary>
        public List<Chore> Chores { get; set; }

        /// <summary>
        /// Gets or sets the trip's categories.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the trip's itineraries.
        /// </summary>
        public List<Itinerary> Itineraries { get; set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new trip.
        /// </summary>
        public Trip()
        {
            Items = new List<Item>();
            Chores = new List<Chore>();
            Categories = new List<Category>();
            Itineraries = new List<Itinerary>();
        } 
        #endregion
    }
}
