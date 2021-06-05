using System.ComponentModel.DataAnnotations;

namespace Travel_list_API.Models.DTO.Authentication
{
    /// <summary>
    /// Represents a login DTO.
    /// </summary>
    public class LoginDTO
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
    }
}
