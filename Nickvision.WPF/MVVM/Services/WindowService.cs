using System.Windows;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with Window.
/// </summary>
public class WindowService : IWindowService
{
    private readonly Window _parent;

    /// <summary>
    /// Constructs a WindowService.
    /// </summary>
    /// <param name="parent">The parent to use if a window is shown as a dialog</param>
    public WindowService(Window parent) => _parent = parent;

    /// <summary>
    /// Shows a window.
    /// </summary>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <param name="viewModel">The ViewModel of the Window</param>
    public void Show<T>(T viewModel) where T : ViewModelBase => viewModel.GetWindowView()?.Show();

    /// <summary>
    /// Shows a window as a dialog.
    /// </summary>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <param name="viewModel">The ViewModel of the Window</param>
    public void ShowDialog<T>(T viewModel) where T : ViewModelBase
    {
        var window = viewModel.GetWindowView();
        if(window != null)
        {
            window.Owner = _parent;
            window.Show();
        }
    }
}
