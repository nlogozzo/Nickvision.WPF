using Nickvision.WPF.Controls;
using System.Threading.Tasks;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with InfoBar.
/// </summary>
public interface IInfoBarService : IService
{
    /// <summary>
    /// Shows a closeable notification.
    /// </summary>
    /// <param name="title">The title of the notification</param>
    /// <param name="message">The message of the notification</param>
    /// <param name="severity">The severity of the notification</param>
    void ShowCloseableNotification(string title, string message, InfoBarSeverity severity);

    /// <summary>
    /// Shows a disappearing notification.
    /// </summary>
    /// <param name="title">The title of the notification</param>
    /// <param name="message">The message of the notification</param>
    /// <param name="severity">The severity of the notification</param>
    /// <param name="timeMilliseconds">The length of time to display the notification (in milliseconds)</param>
    /// <returns></returns>
    Task ShowDisappearingNotificationAsync(string title, string message, InfoBarSeverity severity, int timeMilliseconds);
}
