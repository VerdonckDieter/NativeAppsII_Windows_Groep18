using System;

namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents a user DTO.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the user DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user DTO's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user DTO's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user DTO's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user DTO's birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
