using NativeAppsII_Windows_Groep18.Services.IServices;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public class ContentDialogService : IContentDialogService
    {
        #region Methods
        public async Task<ContentDialogResult> ShowContentDialog(string title, string content, string primaryButtonText, string closeButtonText)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = primaryButtonText,
                CloseButtonText = closeButtonText
            };
            return await contentDialog.ShowAsync();
        }

        public async Task<ContentDialogResult> ShowContentDialog(string title, string content, string closeButtonText)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeButtonText
            };
            return await contentDialog.ShowAsync();
        } 
        #endregion
    }
}
