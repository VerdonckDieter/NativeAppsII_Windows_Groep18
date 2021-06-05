using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_list_API.Models;

namespace Travel_list_API.Data
{
    public class DataInit
    {
        #region Fields
        private readonly Context _db;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion

        #region Constructors
        public DataInit(Context db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task InitializeData()
        {
            await _db.Database.EnsureDeletedAsync();
            if (await _db.Database.EnsureCreatedAsync())
            {
                var user = new User { Email = "client@gmail.com", FirstName = "Dieter", LastName = "D", BirthDate = DateTime.Now };
                await _db.Users.AddAsync(user);

                user = new User { Email = "client2@gmail.com", FirstName = "Dylan", LastName = "D", BirthDate = DateTime.Now };
                await _db.Users.AddAsync(user);

                user = new User { Email = "client3@gmail.com", FirstName = "Thibault", LastName = "D", BirthDate = DateTime.Now };
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();

                await InitializeUsers();
            }
        }

        private async Task InitializeUsers()
        {
            foreach (var user in await _db.Users.ToListAsync())
            {
                var identityUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
                await _userManager.CreateAsync(identityUser, "P@ssword1111");
                await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Role, "user"));
            }
        } 
        #endregion
    }
}
