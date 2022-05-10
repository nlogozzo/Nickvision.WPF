using System.Windows;
using System.Windows.Controls;

namespace Nickvision.WPF.Controls;

/// <summary>
/// An item control to be placed in NavigationBar.
/// </summary>
public partial class NavigationBarItem : ListBoxItem
{
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(NavigationBarItem), new FrameworkPropertyMetadata());
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(NavigationBarItem), new FrameworkPropertyMetadata());
    public static readonly DependencyProperty FilledIconProperty = DependencyProperty.Register("FilledIcon", typeof(string), typeof(NavigationBarItem), new FrameworkPropertyMetadata());

    /// <summary>
    /// Constructs a NavigationBarItem.
    /// </summary>
    public NavigationBarItem()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>
    /// The text of the item (Shown when item not selected).
    /// </summary>
    public string Header
    {
        get => (string)GetValue(HeaderProperty);

        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// The icon of the item (Shown when item not selected).
    /// </summary>
    public string Icon
    {
        get => (string)GetValue(IconProperty);

        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// THe filled version of the icon of the item (Shown when item selected).
    /// </summary>
    public string FilledIcon
    {
        get => (string)GetValue(FilledIconProperty);

        set=> SetValue(FilledIconProperty, value);
    }
}
