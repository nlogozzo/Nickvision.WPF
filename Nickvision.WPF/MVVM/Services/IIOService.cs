namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with IO dialogs.
/// </summary>
public interface IIOService : IService
{
    /// <summary>
    /// Shows an open file dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="filter">The file filter of the dialog</param>
    /// <returns>The opened file path. Null if none selected</returns>
    string? ShowOpenFileDialog(string title, string filter);

    /// <summary>
    /// Shows an open folder dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <returns><The opened folder path. Null if none selected/returns>
    string? ShowOpenFolderDialog(string title);

    /// <summary>
    /// Shows a save file dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="filter">The file filter of the dialog</param>
    /// <param name="defaultExtension">The default extension to use</param>
    /// <returns>The saved file path. Null if none saved</returns>
    string? ShowSaveFileDialog(string title, string filter, string defaultExtension);
}
