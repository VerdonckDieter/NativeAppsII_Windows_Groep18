using NativeAppsII_Windows_Groep18.Model;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface IItemService
    {
        Task<bool> DeleteItem(int categoryId, int itemId);

        Task<Item> UpsertItem(Item item, int categoryId = -1);
    }
}
