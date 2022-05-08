using Nickvision.WPF.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with InfoBar.
/// </summary>
public class InfoBarService : IInfoBarService
{
    private readonly InfoBar _infoBar;

    /// <summary>
    /// Constructs an InfoBarService.
    /// </summary>
    /// <param name="infoBar">The InfoBar UI control</param>
    public InfoBarService(InfoBar infoBar) => _infoBar = infoBar;

    /// <summary>
    /// Shows a closeable notification.
    /// </summary>
    /// <param name="title">The title of the notification</param>
    /// <param name="message">The message of the notification</param>
    /// <param name="severity">The severity of the notification</param>
    public void ShowCloseableNotification(string title, string message, InfoBarSeverity severity)
    {
        _infoBar.Title = title;
        _infoBar.Message = message; 
        _infoBar.Severity = severity;
        _infoBar.CanClose = true;
        _infoBar.Visibility = Visibility.Visible;
    }

    /// <summary>
    /// Shows a disappearing notification.
    /// </summary>
    /// <param name="title">The title of the notification</param>
    /// <param name="message">The message of the notification</param>
    /// <param name="severity">The severity of the notification</param>
    /// <param name="timeMilliseconds">The length of time to display the notification (in milliseconds)</param>
    /// <returns></returns>
    public async Task ShowDisappearingNotificationAsync(string title, string message, InfoBarSeverity severity, int timeMilliseconds)
    {
        _infoBar.Title = title;
        _infoBar.Message = message;
        _infoBar.Severity = severity;
        _infoBar.CanClose = false;
        _infoBar.Visibility = Visibility.Visible;
        await Task.Delay(timeMilliseconds);
        _infoBar.Visibility = Visibility.Collapsed;
    }
}
