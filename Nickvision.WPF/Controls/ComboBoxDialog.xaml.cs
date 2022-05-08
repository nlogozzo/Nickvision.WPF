using MicaWPF.Controls;
using System.Collections.Generic;
using System.Windows;

namespace Nickvision.WPF.Controls;

/// <summary>
/// A control for displaying choices for selection in a dialog.
/// </summary>
public partial class ComboBoxDialog : MicaWindow
{
    private MessageBoxResult _result;

    /// <summary>
    /// Constructs a ComboBoxDialog.
    /// </summary>
    /// <param name="parent">The parent Window of the dialog</param>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    public ComboBoxDialog(Window parent, string title, string description, List<string> choices)
    {
        InitializeComponent();
        _result = MessageBoxResult.Cancel;
        Owner = parent;
        Title = title;
        LblDescription.Text = description;
        CmbChoices.ItemsSource = choices;
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
    /// OOccurs when the Cancel button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        _result = MessageBoxResult.Cancel;
        Close();
    }

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <returns>The selected choice. Null if canceled</returns>
    public new string? ShowDialog()
    {
        base.ShowDialog();
        if(_result == MessageBoxResult.OK)
        {
            return CmbChoices.SelectedItem as string;
        }
        return null;
    }
}
