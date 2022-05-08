using MicaWPF.Controls;
using System.Windows;

namespace Nickvision.WPF.Controls;

/// <summary>
/// The buttons of a MessageBox.
/// </summary>
public enum MessageBoxButtons
{
    YesNo,
    YesNoCancel,
    OK,
    OKCancel,
    Close
}

/// <summary>
/// The icon of a MessageBox.
/// </summary>
public enum MessageBoxIcon
{
    Information,
    Question,
    Warning,
    Error
}

/// <summary>
/// The result of a MessageBox.
/// </summary>
public enum MessageBoxResult
{
    Yes,
    No,
    Cancel,
    OK,
    Close
}

/// <summary>
/// A dialog for showing a message.
/// </summary>
public partial class MessageBox : MicaWindow
{
    private MessageBoxResult _result;

    /// <summary>
    /// Constructs a MessageBox.
    /// </summary>
    /// <param name="parent">The parent Window of the dialog</param>
    /// <param name="title">The title of the message.</param>
    /// <param name="message">The message.</param>
    /// <param name="buttons">The buttons to show in the dialog.</param>
    /// <param name="icon">The icon of the dialog</param>
    public MessageBox(Window parent, string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        InitializeComponent();
        _result = MessageBoxResult.Close;
        Owner = parent;
        Title = title;
        LblMsg.Text = message;
        LblIcon.Text = icon switch
        {
            MessageBoxIcon.Information => "\xe783",
            MessageBoxIcon.Question => "\xe9ce",
            MessageBoxIcon.Warning => "\xe7ba",
            MessageBoxIcon.Error => "\xea39",
            _ => "\xe783"
        };
        BtnYes.Visibility = buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel ? Visibility.Visible : Visibility.Collapsed;
        BtnNo.Visibility = buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel ? Visibility.Visible : Visibility.Collapsed;
        BtnCancel.Visibility = buttons == MessageBoxButtons.YesNoCancel || buttons == MessageBoxButtons.OKCancel ? Visibility.Visible : Visibility.Collapsed;
        BtnOK.Visibility = buttons == MessageBoxButtons.OK || buttons == MessageBoxButtons.OKCancel ? Visibility.Visible : Visibility.Collapsed;
        BtnClose.Visibility = buttons == MessageBoxButtons.Close ? Visibility.Visible : Visibility.Collapsed;
    }

    /// <summary>
    /// Occurs when the Save button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnYes_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.Yes;
        Close();
    }

    /// <summary>
    /// Occurs when the No button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnNo_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.No;
        Close();
    }

    /// <summary>
    /// Occurs when the OK button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnOK_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.OK;
        Close();
    }

    /// <summary>
    /// Occurs when the Cancel button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.Cancel;
        Close();
    }

    /// <summary>
    /// Occurs when the Close button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.Close;
        Close();
    }

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <returns>The result of the dialog. (The button clicked)</returns>
    public new MessageBoxResult ShowDialog()
    {
        base.ShowDialog();
        return _result;
    }
}
