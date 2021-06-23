using NativeAppsII_Windows_Groep18.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface ITripService
    {
        Task<List<Trip>> GetTrips();

        Task<Trip> GetTrip(int id);

        Task<bool> DeleteTrip(int id);
    }
}
