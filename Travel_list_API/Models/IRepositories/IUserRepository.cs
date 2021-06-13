using System.Collections.Generic;
using System.Threading.Tasks;
using Travel_list_API.Models.DTO;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the users backend.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all users. 
        /// </summary>
        Task<IEnumerable<UserDTO>> GetUsersAsync();

        /// <summary>
        /// Returns the user with the given email. 
        /// </summary>
        Task<UserDTO> GetUserAsync(string email);

        /// <summary>
        /// Adds a new user if the user does not exist, updates the 
        /// existing user otherwise.
        /// </summary>
        Task<bool> UpsertUserAsync(User user);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        Task DeleteUserAsync(int id);
    }
}
