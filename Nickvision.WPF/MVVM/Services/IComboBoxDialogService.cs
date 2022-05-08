using System.Collections.Generic;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with ComboBoxDialog.
/// </summary>
public interface IComboBoxDialogService : IService
{
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    /// <returns>The selected choice. Null if canceled</returns>
    string? ShowDialog(string title, string description, List<string> choices);
}
