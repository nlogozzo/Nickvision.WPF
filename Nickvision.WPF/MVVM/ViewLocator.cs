using System;
using System.Windows;
using System.Windows.Controls;

namespace Nickvision.WPF.MVVM;

/// <summary>
/// Extension methods for getting Views from ViewModels.
/// </summary>
public static class ViewLocator
{
    /// <summary>
    /// Gets the View object associated with the provided ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel associated with the View</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The View object associated with the ViewModel. Null if no View can be found</returns>
    private static object? GetObjectView<T>(this T viewModel) where T : ViewModelBase
    {
        var name = viewModel.GetType().AssemblyQualifiedName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);
        return type != null ? Activator.CreateInstance(type)! : null;
    }

    /// <summary>
    /// Gets the UserControl associated with the provided ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel associated with the UserControl</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The UserControl associated with the ViewModel. Null if no UserControl can be found</returns>
    public static UserControl? GetUserControlView<T>(this T viewModel) where T : ViewModelBase
    {
        var userControl = (UserControl?)GetObjectView(viewModel);
        if (userControl != null)
        {
            userControl.DataContext = viewModel;
        }
        return userControl;
    }

    /// <summary>
    /// Gets the Page associated with the provided ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel associated with the UserControl</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The Page associated with the ViewModel. Null if no Page can be found</returns>
    public static Page? GetPageView<T>(this T viewModel) where T : ViewModelBase
    {
        var page = (Page?)GetObjectView(viewModel);
        if (page != null)
        {
            page.DataContext = viewModel;
        }
        return page;
    }

    /// <summary>
    /// Gets the Window associated with the provided ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel associated with the UserControl</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The Window associated with the ViewModel. Null if no Window can be found</returns>
    public static Window? GetWindowView<T>(this T viewModel) where T : ViewModelBase
    {
        var window = (Window?)GetObjectView(viewModel);
        if (window != null)
        {
            window.DataContext = viewModel;
        }
        return window;
    }
}