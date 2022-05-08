using Ookii.Dialogs.Wpf;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with IO dialogs.
/// </summary>
public class IOService : IIOService
{
    /// <summary>
    /// Shows an open file dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="filter">The file filter of the dialog</param>
    /// <returns>The opened file path. Null if none selected</returns>
    public string? ShowOpenFileDialog(string title, string filter)
    {
        var openFileDialog = new VistaOpenFileDialog();
        openFileDialog.Title = title;
        openFileDialog.Filter = filter;
        if(openFileDialog.ShowDialog() == true)
        {
            return openFileDialog.FileName;
        }
        return null;
    }

    /// <summary>
    /// Shows an open folder dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <returns><The opened folder path. Null if none selected/returns>
    public string? ShowOpenFolderDialog(string title)
    {
        var openFolderDialog = new VistaFolderBrowserDialog();
        openFolderDialog.Description = title;
        openFolderDialog.UseDescriptionForTitle = true;
        if (openFolderDialog.ShowDialog() == true)
        {
            return openFolderDialog.SelectedPath;
        }
        return null;
    }

    /// <summary>
    /// Shows a save file dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="filter">The file filter of the dialog</param>
    /// <param name="defaultExtension">The default extension to use</param>
    /// <returns>The saved file path. Null if none saved</returns>
    public string? ShowSaveFileDialog(string title, string filter, string defaultExtension)
    {
        var saveFileDialog = new VistaSaveFileDialog();
        saveFileDialog.Title = title;
        saveFileDialog.Filter = filter;
        saveFileDialog.DefaultExt = defaultExtension;
        if (saveFileDialog.ShowDialog() == true)
        {
            return saveFileDialog.FileName;
        }
        return null;
    }
}
