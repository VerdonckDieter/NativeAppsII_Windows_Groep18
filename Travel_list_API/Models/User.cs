using System.Collections.Generic;

namespace Travel_list_API.Models
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User
    {
        #region Properties
        /// <summary>
        /// Gets or sets the user's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's trips.
        /// </summary>
        public List<Trip> Trips { get; set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new user.
        /// </summary>
        public User()
        {
            Trips = new List<Trip>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new trip to the user's trips.
        /// </summary>
        /// <param name="trip">The trip to add</param>
        public void AddTrip(Trip trip) => Trips.Add(trip);

        /// <summary>
        /// Removes a trip from the user's trips.
        /// </summary>
        /// <param name="trip">The trip to remove</param>
        public void RemoveTrip(Trip trip) => Trips.Remove(trip); 
        #endregion
    }
}
