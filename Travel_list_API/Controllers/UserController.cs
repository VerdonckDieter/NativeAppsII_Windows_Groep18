using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.DTO.Authentication;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with user data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public UserController(IUserRepository clientRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userRepository = clientRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        [HttpGet("GetUsers")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersAsync()
        {
            try
            {
                return Ok(await _userRepository.GetUsersAsync());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets the current logged in user.
        /// </summary>
        [HttpGet("GetUser")]
        [Authorize(Policy = "User")]
        public async Task<ActionResult<UserDTO>> GetUserAsync()
        {
            try
            {
                return Ok(await _userRepository.GetUserAsync(User.Identity.Name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]RegisterDTO model)
        {
            var identityUser = new IdentityUser { UserName = model.Email, Email = model.Email };
            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userManager.CreateAsync(identityUser, model.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Role, "client"));

                if (result.Succeeded && await _userRepository.UpsertUserAsync(user))
                    return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, model.Password, false)).Succeeded)
                return Created("", await GetToken(user));
            return BadRequest();
        }

        /// <summary>
        /// Creates a JWT token based on the provided IdentityUser and append claim information.
        /// </summary>
        private async Task<string> GetToken(IdentityUser user)
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName) };
            claims.AddRange((await _userManager.GetClaimsAsync(user)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                null, null,
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
