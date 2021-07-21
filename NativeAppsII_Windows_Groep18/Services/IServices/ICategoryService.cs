using NativeAppsII_Windows_Groep18.Model;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface ICategoryService
    {
        Task<bool> DeleteCategory(int tripId, int categoryId);

        Task<Category> UpsertCategory(Category category, int tripId = -1);
    }
}
