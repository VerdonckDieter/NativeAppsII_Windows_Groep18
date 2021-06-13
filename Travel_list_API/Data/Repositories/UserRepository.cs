using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the users backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public UserRepository(Context db) => _db = db;
        #endregion

        #region Methods
        /// <summary>
        /// Returns all users. 
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            return await _db.Users
                .AsNoTracking()
                .Select(u => new UserDTO { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName })
                .ToListAsync();
        }

        /// <summary>
        /// Returns the user with the given email. 
        /// </summary>
        public async Task<UserDTO> GetUserAsync(string email)
        {
            return await _db.Users
                .AsNoTracking()
                .Select(u => new UserDTO { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName })
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        /// <summary>
        /// Adds a new user if the user does not exist, updates the 
        /// existing user otherwise.
        /// </summary>
        public async Task<bool> UpsertUserAsync(User user)
        {
            var current = await _db.Users.FirstOrDefaultAsync(_user => _user.Id == user.Id);
            if (current == null)
            {
                _db.Users.Add(user);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(user);
            }
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        public async Task DeleteUserAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(_user => _user.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        } 
        #endregion
    }
}
