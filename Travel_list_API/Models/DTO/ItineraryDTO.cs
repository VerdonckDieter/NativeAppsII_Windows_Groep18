namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents an itinerary DTO.
    /// </summary>
    public class ItineraryDTO
    {
        /// <summary>
        /// Gets or sets the itinerary DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the itinerary DTO's start latitude.
        /// </summary>
        public double StartLatitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary DTO's start longitude.
        /// </summary>
        public double StartLongitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary DTO's end latitude.
        /// </summary>
        public double EndLatitude { get; set; }

        /// <summary>
        /// Gets or sets the itinerary DTO's end longitude.
        /// </summary>
        public double EndLongitude { get; set; }
    }
}
