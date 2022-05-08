using Nickvision.WPF.Controls;
using System.Collections.Generic;
using System.Windows;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with ComboBoxDialog.
/// </summary>
public class ComboBoxDialogService : IComboBoxDialogService
{
    private readonly Window _parent;

    /// <summary>
    /// Constructs a ComboBoxDialogService.
    /// </summary>
    /// <param name="parent">The parent of the dialog</param>
    public ComboBoxDialogService(Window parent) => _parent = parent;

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    /// <returns>The selected choice. Null if canceled</returns>
    public string? ShowDialog(string title, string description, List<string> choices) => new ComboBoxDialog(_parent, title, description, choices).ShowDialog();
}
