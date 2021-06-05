namespace Travel_list_API.Models
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

        /// <summary>
        /// Creates a new itinerary.
        /// </summary>
        /// <param name="startLatitude">The itinerary's start latitude</param>
        /// <param name="startLongitude">The itinerary's start longitude</param>
        /// <param name="endLatitude">The itinerary's end latitude</param>
        /// <param name="endLongitude">The itinerary's end longitude</param>
        public Itinerary(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            StartLatitude = startLatitude;
            StartLongitude = startLongitude;
            EndLatitude = endLatitude;
            EndLongitude = endLongitude;
        } 
        #endregion
    }
}
