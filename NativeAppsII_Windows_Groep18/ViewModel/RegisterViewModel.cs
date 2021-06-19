using System.Threading.Tasks;
using NativeAppsII_Windows_Groep18.Services.IServices;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class RegisterViewModel
    {
        private IUserService _userService;

        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<string> Register(string email, string password, string firstname, string lastname)
        {
            return await _userService.Register(email, password, firstname, lastname);
        }

        public async Task<string> CheckAvailableUsername(string email)
        {
            return await _userService.CheckAvailableUsername(email);
        }
    }
}
