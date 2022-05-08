using Nickvision.WPF.Controls;
using System.Windows;
using MessageBox = Nickvision.WPF.Controls.MessageBox;
using MessageBoxResult = Nickvision.WPF.Controls.MessageBoxResult;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with MessageBox.
/// </summary>
public class MessageBoxService : IMessageBoxService
{
    private readonly Window _parent;

    /// <summary>
    /// Constructs a MessageBoxService.
    /// </summary>
    /// <param name="parent">The parent of the dialog</param>
    public MessageBoxService(Window parent) => _parent = parent;

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the message.</param>
    /// <param name="message">The message.</param>
    /// <param name="buttons">The buttons to show in the dialog.</param>
    /// <param name="icon">The icon of the dialog</param>
    /// <returns>The result of the dialog. (The button clicked)</returns>
    public MessageBoxResult ShowDialog(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon) => new MessageBox(_parent, title, message, buttons, icon).ShowDialog();
}
