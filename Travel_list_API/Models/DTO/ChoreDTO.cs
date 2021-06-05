namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents a chore DTO.
    /// </summary>
    public class ChoreDTO
    {
        /// <summary>
        /// Gets or sets the chore DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the chore DTO's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the chore DTO is completed.
        /// </summary>
        public bool Completed { get; set; }
    }
}
