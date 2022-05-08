namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with Window.
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// Shows a window.
    /// </summary>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <param name="viewModel">The ViewModel of the Window</param>
    void Show<T>(T viewModel) where T : ViewModelBase;

    /// <summary>
    /// Shows a window as a dialog.
    /// </summary>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <param name="viewModel">The ViewModel of the Window</param>
    void ShowDialog<T>(T viewModel) where T : ViewModelBase;
}
