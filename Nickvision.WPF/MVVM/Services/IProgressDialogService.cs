using System;
using System.Threading.Tasks;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with ProgressDialog.
/// </summary>
public interface IProgressDialogService : IService
{
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="description">The description of the long task</param>
    /// <param name="action">The long task to complete</param>
    void ShowDialog(string description, Func<Task> action);
}
