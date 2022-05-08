using Nickvision.WPF.Controls;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with MessageBox.
/// </summary>
public interface IMessageBoxService : IService
{
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the message.</param>
    /// <param name="message">The message.</param>
    /// <param name="buttons">The buttons to show in the dialog.</param>
    /// <param name="icon">The icon of the dialog</param>
    /// <returns>The result of the dialog. (The button clicked)</returns>
    MessageBoxResult ShowDialog(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon);
}
