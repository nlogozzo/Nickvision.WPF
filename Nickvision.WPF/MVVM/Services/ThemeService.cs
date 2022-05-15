using HandyControl.Themes;
using MicaWPF;
using System.Windows.Media;

namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// A service for working with an application's theme.
/// </summary>
public class ThemeService : IThemeService
{
    /// <summary>
    /// Changes the theme of the application.
    /// </summary>
    /// <param name="theme">The theme</param>
    public void ChangeTheme(Theme theme)
    {
        ThemeManager.Current.UsingSystemTheme = false;
        MicaWPF.Services.ThemeService.GetCurrent().ChangeTheme(theme switch
        {
            Theme.Light => WindowsTheme.Light,
            Theme.Dark => WindowsTheme.Dark,
            Theme.System => WindowsTheme.Auto,
            _ => WindowsTheme.Auto
        });
        ThemeManager.Current.ApplicationTheme = theme switch
        {
            Theme.Light => ApplicationTheme.Light,
            Theme.Dark => ApplicationTheme.Dark,
            Theme.System => null,
            _ => ApplicationTheme.Dark
        };
        if(theme == Theme.System)
        {
            ThemeManager.Current.UsingSystemTheme = true;
        }
    }

    /// <summary>
    /// Changes the accent color of the application.
    /// </summary>
    /// <param name="theme">The accent color</param>
    public void ChangeAccentColor(AccentColor accentColor)
    {
        ThemeManager.Current.AccentColor = accentColor switch
        {
            AccentColor.System => ThemeManager.Current.GetAccentColorFromSystem(),
            AccentColor.Red => Brushes.Red,
            AccentColor.Orange => Brushes.Orange,
            AccentColor.Yellow => Brushes.Yellow,
            AccentColor.Green => Brushes.Green,
            AccentColor.Blue => Brushes.Blue,
            AccentColor.Purple => Brushes.Purple,
            AccentColor.Pink => Brushes.HotPink,
            AccentColor.Brown => Brushes.SaddleBrown,
            AccentColor.Black => Brushes.Black,
            AccentColor.White => Brushes.White,
            _ => ThemeManager.Current.GetAccentColorFromSystem()
        };
    }
}
