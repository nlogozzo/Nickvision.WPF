using Nickvision.WPF.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with ProgressDialog.
/// </summary>
public class ProgressDialogService : IProgressDialogService
{
    private readonly Window _parent;

    /// <summary>
    /// Constructs a ProgressDialogService.
    /// </summary>
    /// <param name="parent">The parent of the dialog</param>
    public ProgressDialogService(Window parent) => _parent = parent;

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="description">The description of the long task</param>
    /// <param name="action">The long task to complete</param>
    public void ShowDialog(string description, Func<Task> action) => new ProgressDialog(_parent, description, action).ShowDialog();
}
