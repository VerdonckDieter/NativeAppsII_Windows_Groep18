using System.Threading.Tasks;
using NativeAppsII_Windows_Groep18.Services.IServices;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class LoginViewModel
    {
        #region Fields
        private IUserService _userService;
        #endregion

        #region Constructors
        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods
        public async Task<string> Login(string email, string password)
        {
            return await _userService.Login(email, password);
        }
        #endregion
    }
}
