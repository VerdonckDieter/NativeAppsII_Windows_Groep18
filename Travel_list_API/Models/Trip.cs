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
            Chores = new List<Chore>();
            Categories = new List<Category>();
            Itineraries = new List<Itinerary>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new chore to the trip.
        /// </summary>
        /// <param name="chore">The chore to add</param>
        public void AddChore(Chore chore) => Chores.Add(chore);

        /// <summary>
        /// Removes a chore from the trip.
        /// </summary>
        /// <param name="chore">The chore to remove</param>
        public void RemoveChore(Chore chore) => Chores.Remove(chore);

        /// <summary>
        /// Adds a new category to the trip.
        /// </summary>
        /// <param name="category">The category to add</param>
        public void AddCategory(Category category) => Categories.Add(category);

        /// <summary>
        /// Removes a category from the trip.
        /// </summary>
        /// <param name="category">The category to remove</param>
        public void RemoveCategory(Category category) => Categories.Remove(category);

        /// <summary>
        /// Adds a new itinerary to the trip.
        /// </summary>
        /// <param name="itinerary">The itinerary to add</param>
        public void AddItinerary(Itinerary itinerary) => Itineraries.Add(itinerary);

        /// <summary>
        /// Removes a itinerary from the trip.
        /// </summary>
        /// <param name="itinerary">The itinerary to remove</param>
        public void RemoveItinerary(Itinerary itinerary) => Itineraries.Remove(itinerary); 
        #endregion
    }
}
