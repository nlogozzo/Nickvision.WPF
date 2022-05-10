using HandyControl.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Nickvision.WPF.Controls;

/// <summary>
/// The severity of the InfoBar message.
/// </summary>
public enum InfoBarSeverity
{
    Information,
    Warning,
    Error,
    Success
}

/// <summary>
/// A control for showing a message.
/// </summary>
public partial class InfoBar : Border
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoBar), new FrameworkPropertyMetadata());
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(InfoBar), new FrameworkPropertyMetadata());
    public static readonly DependencyProperty SeverityProperty = DependencyProperty.Register("Severity", typeof(InfoBarSeverity), typeof(InfoBar), new FrameworkPropertyMetadata() { PropertyChangedCallback = OnSeverityChanged });
    public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(InfoBar), new FrameworkPropertyMetadata() { DefaultValue = true, PropertyChangedCallback = OnCanCloseChanged });

    /// <summary>
    /// Constructs an InfoBar.
    /// </summary>
    public InfoBar()
    {
        InitializeComponent();
    }

    /// <summary>
    /// The title of the message.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);

        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// The message.
    /// </summary>
    public string Message
    {
        get => (string)GetValue(MessageProperty);

        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// The severity of the message.
    /// </summary>
    public InfoBarSeverity Severity
    {
        get => (InfoBarSeverity)GetValue(SeverityProperty);

        set => SetValue(SeverityProperty, value);
    }

    /// <summary>
    /// Whether or not the InfoBar can be closed by the user.
    /// </summary>
    public bool CanClose
    {
        get => (bool)GetValue(CanCloseProperty);

        set => SetValue(CanCloseProperty, value);
    }

    /// <summary>
    /// Occurs when the Severity property is changed.
    /// </summary>
    /// <param name="sender">InfoBar</param>
    /// <param name="e">Unused.</param>
    public static void OnSeverityChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var infobar = (sender as InfoBar)!;
        infobar.Background = infobar.Severity switch
        {
            InfoBarSeverity.Information => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
            InfoBarSeverity.Warning => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(255, 244, 206)) : new SolidColorBrush(Color.FromRgb(67, 53, 25)),
            InfoBarSeverity.Error => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(253, 231, 233)) : new SolidColorBrush(Color.FromRgb(68, 39, 38)),
            InfoBarSeverity.Success => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(223, 246, 221)) : new SolidColorBrush(Color.FromRgb(57, 61, 27)),
            _ => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
        };
        infobar.LblIcon.Text = infobar.Severity switch
        {
            InfoBarSeverity.Information => "\xe783",
            InfoBarSeverity.Warning => "\xe7ba",
            InfoBarSeverity.Error => "\xea39",
            InfoBarSeverity.Success => "\xe930",
            _ => "\xe783"
        };
    }

    /// <summary>
    /// Occurs when the CanClose property is changed.
    /// </summary>
    /// <param name="sender">InfoBar</param>
    /// <param name="e">Unused.</param>
    public static void OnCanCloseChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var infobar = (sender as InfoBar)!;
        infobar.BtnClose.Visibility = infobar.CanClose ? Visibility.Visible : Visibility.Collapsed;
    }

    /// <summary>
    /// Occurs when the InfoBar is loaded.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void InfoBar_Loaded(object sender, RoutedEventArgs e)
    {
        ThemeManager.Current.SystemThemeChanged += (sender, e) =>
        {
            Background = Severity switch
            {
                InfoBarSeverity.Information => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
                InfoBarSeverity.Warning => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(255, 244, 206)) : new SolidColorBrush(Color.FromRgb(67, 53, 25)),
                InfoBarSeverity.Error => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(253, 231, 233)) : new SolidColorBrush(Color.FromRgb(68, 39, 38)),
                InfoBarSeverity.Success => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(223, 246, 221)) : new SolidColorBrush(Color.FromRgb(57, 61, 27)),
                _ => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
            };
        };
    }

    /// <summary>
    /// Occurs when the Close button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnClose_Click(object sender, RoutedEventArgs e) => Visibility = Visibility.Collapsed;
}
