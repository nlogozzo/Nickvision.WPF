using System.Windows;
using System.Windows.Controls;

namespace Nickvision.WPF.Controls;

/// <summary>
/// A control for showing page navigation items.
/// </summary>
public partial class NavigationBar : UserControl
{
    public static readonly DependencyProperty TopItemsProperty = DependencyProperty.Register("TopItems", typeof(FreezableCollection<NavigationBarItem>), typeof(NavigationBar), new FrameworkPropertyMetadata() { IsNotDataBindable = true });
    public static readonly DependencyProperty BottomItemsProperty = DependencyProperty.Register("BottomItems", typeof(FreezableCollection<NavigationBarItem>), typeof(NavigationBar), new FrameworkPropertyMetadata() { IsNotDataBindable = true });
    public static readonly DependencyProperty SelectFirstItemOnLoadedProperty = DependencyProperty.Register("SelectFirstItemOnLoaded", typeof(bool), typeof(NavigationBar), new FrameworkPropertyMetadata() { DefaultValue = true });
    public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(NavigationBar), new FrameworkPropertyMetadata() { DefaultValue = -1, BindsTwoWayByDefault = true });

    /// <summary>
    /// Constructs a NavigationBar.
    /// </summary>
    public NavigationBar()
    {
        InitializeComponent();
        TopItems = new FreezableCollection<NavigationBarItem>();
        BottomItems = new FreezableCollection<NavigationBarItem>();
    }

    /// <summary>
    /// The items to display in the top section of the NavigationBar.
    /// </summary>
    public FreezableCollection<NavigationBarItem> TopItems
    {
        get => (FreezableCollection<NavigationBarItem>)GetValue(TopItemsProperty);

        set => SetValue(TopItemsProperty, value);
    }

    /// <summary>
    /// The items to display in the bottom section of the NavigationBar.
    /// </summary>
    public FreezableCollection<NavigationBarItem> BottomItems
    {
        get => (FreezableCollection<NavigationBarItem>)GetValue(BottomItemsProperty);

        set => SetValue(BottomItemsProperty, value);
    }

    /// <summary>
    /// Whether or not to select the first item of the NavigationBar when the loaded event occurs.
    /// </summary>
    public bool SelectFirstItemOnLoaded
    {
        get => (bool)GetValue(SelectFirstItemOnLoadedProperty);

        set => SetValue(SelectFirstItemOnLoadedProperty, value);
    }

    /// <summary>
    /// The index of the selected item.
    /// </summary>
    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);

        set => SetValue(SelectedIndexProperty, value);
    }

    /// <summary>
    /// Occurs when the NavigationBar is loaded.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void NavigationBar_Loaded(object sender, RoutedEventArgs e)
    {
        if(SelectFirstItemOnLoaded && ListTopItems.Items.Count > 0)
        {
            ListTopItems.SelectedIndex = 0;
        }
        for(int i = 0; i < ListTopItems.Items.Count; i++)
        {
            (ListTopItems.Items[i] as NavigationBarItem)!.Margin = i == 0 ? new Thickness(6, 0, 6, 0) : new Thickness(6, 6, 6, 0);
        }
        for(int i = 0; i < ListBottomItems.Items.Count; i++)
        {
            (ListBottomItems.Items[i] as NavigationBarItem)!.Margin = i == 0 ? new Thickness(6, 0, 6, 0) : new Thickness(6, 6, 6, 0);
        }
    }

    /// <summary>
    /// Occurs when a selection of the NavigationBar is changed.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">SelectionChangedEventArgs</param>
    private void NavigationBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.AddedItems.Count > 0)
        {
            if (sender == ListTopItems)
            {
                ListBottomItems.SelectedIndex = -1;
            }
            else if (sender == ListBottomItems)
            {
                ListTopItems.SelectedIndex = -1;
            }
            SelectedIndex = ListTopItems.SelectedIndex != -1 ? ListTopItems.SelectedIndex : ListBottomItems.SelectedIndex + ListTopItems.Items.Count;
        }
        if(ListTopItems.SelectedIndex == -1 && ListBottomItems.SelectedIndex == -1 && e.RemovedItems.Count > 0)
        {
            var removedItem = e.RemovedItems[0];
            if(ListTopItems.Items.Contains(removedItem))
            {
                ListTopItems.SelectedItem = removedItem;
            }
            else if(ListBottomItems.Items.Contains(removedItem))
            {
                ListBottomItems.SelectedItem = removedItem;
            }
            SelectedIndex = ListTopItems.SelectedIndex != -1 ? ListTopItems.SelectedIndex : ListBottomItems.SelectedIndex + ListTopItems.Items.Count;
        }
    }
}
