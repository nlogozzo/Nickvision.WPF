using MicaWPF.Controls;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Nickvision.WPF.Controls;

/// <summary>
/// A control for running a long task and displaying Progress in a blocking dialog.
/// </summary>
public partial class ProgressDialog : MicaWindow
{
    private readonly Func<Task> _action;
    private bool _isFinished;

    /// <summary>
    /// Constructs a ProgressDialog.
    /// </summary>
    /// <param name="parent">The parent Window of the dialog</param>
    /// <param name="description">The description of the task</param>
    /// <param name="action">The long task</param>
    public ProgressDialog(Window parent, string description, Func<Task> action)
    {
        InitializeComponent();
        _action = action;
        _isFinished = false;
        Owner = parent;
        LblDescription.Text = description;
    }

    /// <summary>
    /// Occurs when the dialog is loaded.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private async void Dialog_Loaded(object sender, RoutedEventArgs e)
    {
        await _action();
        _isFinished = true;
        Close();
    }

    /// <summary>
    /// Occurs when the dialog is closing.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void Dialog_Closing(object sender, CancelEventArgs e)
    {
        if(!_isFinished)
        {
            e.Cancel = true;
        }
    }
}
