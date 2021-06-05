using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Data.Repositories.IRepositories;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;

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
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            return await _db.Users
                .AsNoTracking()
                .Select(u => new UserDTO { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName })
                .ToListAsync();
        }

        public async Task<UserDTO> GetUserAsync(string email, int id)
        {
            return await _db.Users
                .AsNoTracking()
                .Select(u => new UserDTO { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName })
                .FirstOrDefaultAsync(user => user.Email == email && user.Id == id);
        }

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
