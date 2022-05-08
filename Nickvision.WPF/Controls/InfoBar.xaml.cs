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
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoBar), new PropertyMetadata(null));
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(InfoBar), new PropertyMetadata(null));
    public static readonly DependencyProperty SeverityProperty = DependencyProperty.Register("Severity", typeof(InfoBarSeverity), typeof(InfoBar), new PropertyMetadata(null));
    public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(InfoBar), new PropertyMetadata(null));

    /// <summary>
    /// Constructs an InfoBar.
    /// </summary>
    public InfoBar()
    {
        InitializeComponent();
        DataContext = this;
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

        set
        {
            SetValue(SeverityProperty, value);
            Background = Severity switch
            {
                InfoBarSeverity.Information => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
                InfoBarSeverity.Warning => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(255, 244, 206)) : new SolidColorBrush(Color.FromRgb(67, 53, 25)),
                InfoBarSeverity.Error => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(253, 231, 233)) : new SolidColorBrush(Color.FromRgb(68, 39, 38)),
                InfoBarSeverity.Success => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(223, 246, 221)) : new SolidColorBrush(Color.FromRgb(57, 61, 27)),
                _ => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
            };
            LblIcon.Text = Severity switch
            {
                InfoBarSeverity.Information => "\xe783",
                InfoBarSeverity.Warning => "\xe7ba",
                InfoBarSeverity.Error => "\xea39",
                InfoBarSeverity.Success => "\xe930",
                _ => "\xe783"
            };
        }
    }

    /// <summary>
    /// Whether or not the InfoBar can be closed by the user.
    /// </summary>
    public bool CanClose
    {
        get => (bool)GetValue(CanCloseProperty);

        set
        {
            SetValue(CanCloseProperty, value);
            BtnClose.Visibility = CanClose ? Visibility.Visible : Visibility.Collapsed;
        }
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
        Background = Severity switch
        {
            InfoBarSeverity.Information => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
            InfoBarSeverity.Warning => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(255, 244, 206)) : new SolidColorBrush(Color.FromRgb(67, 53, 25)),
            InfoBarSeverity.Error => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(253, 231, 233)) : new SolidColorBrush(Color.FromRgb(68, 39, 38)),
            InfoBarSeverity.Success => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(223, 246, 221)) : new SolidColorBrush(Color.FromRgb(57, 61, 27)),
            _ => ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light ? new SolidColorBrush(Color.FromRgb(76, 194, 255)) : new SolidColorBrush(Color.FromRgb(0, 120, 212)),
        };
        LblIcon.Text = Severity switch
        {
            InfoBarSeverity.Information => "\xe783",
            InfoBarSeverity.Warning => "\xe7ba",
            InfoBarSeverity.Error => "\xea39",
            InfoBarSeverity.Success => "\xe930",
            _ => "\xe783"
        };
        BtnClose.Visibility = CanClose ? Visibility.Visible : Visibility.Collapsed;
    }

    /// <summary>
    /// Occurs when the Close button is clicked.
    /// </summary>
    /// <param name="sender">Unused.</param>
    /// <param name="e">Unused.</param>
    private void BtnClose_Click(object sender, RoutedEventArgs e) => Visibility = Visibility.Collapsed;
}
