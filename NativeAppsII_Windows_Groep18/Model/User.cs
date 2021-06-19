using System.Collections.ObjectModel;

namespace NativeAppsII_Windows_Groep18.Model
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
        public ObservableCollection<Trip> Trips { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new user.
        /// </summary>
        public User() => Trips = new ObservableCollection<Trip>();
        #endregion
    }
}
