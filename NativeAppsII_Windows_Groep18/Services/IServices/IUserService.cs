using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);

        Task<string> Register(string email, string password, string firstname, string lastname);

        Task<string> CheckAvailableUsername(string email);
    }
}
