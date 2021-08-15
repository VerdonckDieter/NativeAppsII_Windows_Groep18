using System;
using System.Collections.ObjectModel;
using System.Linq;

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

        /// <summary>
        /// Gets the trip's item progress.
        /// </summary>
        public double ItemProgress
        {
            get
            {
                int totalItems = Categories.Sum(c => c.Items.Count);
                return totalItems == 0 ? 0 : Convert.ToDouble(Categories.Sum(c => c.ItemsAdded)) / totalItems * 100;
            }
        }

        /// <summary>
        /// Gets the trip's chore progress.
        /// </summary>
        public double ChoreProgress
        {
            get
            {
                int totalChores = Chores.Count;
                return totalChores == 0 ? 0 : Convert.ToDouble(Chores.Count(c => c.Completed)) / totalChores * 100;
            }
        }
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
