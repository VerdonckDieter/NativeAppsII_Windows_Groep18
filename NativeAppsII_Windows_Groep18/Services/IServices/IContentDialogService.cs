using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NativeAppsII_Windows_Groep18.Services.IServices
{
    public interface IContentDialogService
    {
        Task<ContentDialogResult> ShowContentDialog(string title, string content, string primaryButtonText, string closeButtonText);
    }
}
