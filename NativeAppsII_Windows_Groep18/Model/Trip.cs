﻿using System;
using System.Collections.ObjectModel;

namespace NativeAppsII_Windows_Groep18.Model
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
        /// Gets or sets the trip's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the trip's location.
        /// </summary>
        public string Location { get; set; }

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
        public ObservableCollection<Chore> Chores { get; set; }

        /// <summary>
        /// Gets or sets the trip's categories.
        /// </summary>
        public ObservableCollection<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the trip's itineraries.
        /// </summary>
        public ObservableCollection<Itinerary> Itineraries { get; set; }

        /// <summary>
        /// Gets the trip's time period.
        /// </summary>
        public string Period => StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new trip.
        /// </summary>
        public Trip()
        {
            Chores = new ObservableCollection<Chore>();
            Categories = new ObservableCollection<Category>();
            Itineraries = new ObservableCollection<Itinerary>();
        }
        #endregion
    }
}
