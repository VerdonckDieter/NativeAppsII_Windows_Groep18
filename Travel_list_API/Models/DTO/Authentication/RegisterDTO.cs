using System;
using System.ComponentModel.DataAnnotations;

namespace Travel_list_API.Models.DTO.Authentication
{
    /// <summary>
    /// Represents a register DTO.
    /// </summary>
    public class RegisterDTO
    {
        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's birth date.
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
