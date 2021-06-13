namespace NativeAppsII_Windows_Groep18.Model
{
    /// <summary>
    /// Represents an itinerary.
    /// </summary>
    public class Itinerary
    {
        #region Properties
        /// <summary>
        /// Gets or sets the itinerary's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the itinerary's start latitude.
        /// </summary>
        public double StartLatitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary's start longitude.
        /// </summary>
        public double StartLongitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary's end latitude.
        /// </summary>
        public double EndLatitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary's end longitude.
        /// </summary>
        public double EndLongitude { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new itinerary.
        /// </summary>
        public Itinerary() { }
        #endregion
    }
}
