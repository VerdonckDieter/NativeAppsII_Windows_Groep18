using NativeAppsII_Windows_Groep18.Model;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface IChoreService
    {
        Task<bool> DeleteChore(int tripId, int choreId);

        Task<Chore> UpsertChore(Chore chore, int tripId = -1);
    }
}
