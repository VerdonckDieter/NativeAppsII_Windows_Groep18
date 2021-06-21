using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace NativeAppsII_Windows_Groep18.Services.Instances
{
    public static class ToastService
    {
        public static void MakeToast(string text)
        {
            var content = new ToastContentBuilder()
                .AddText(text)
                .SetToastDuration(ToastDuration.Short)
                .GetToastContent();
            var notification = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }
    }
}
