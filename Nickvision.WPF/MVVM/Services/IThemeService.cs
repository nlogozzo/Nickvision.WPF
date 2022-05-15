namespace Nickvision.WPF.MVVM.Services;

/// <summary>
/// The themes an application can have.
/// </summary>
public enum Theme
{
    Light,
    Dark,
    System
}

/// <summary>
/// The accent colors an application can have.
/// </summary>
public enum AccentColor
{
    System,
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple,
    Pink,
    Brown,
    Black,
    White
}

/// <summary>
/// A service for working with an application's theme.
/// </summary>
public interface IThemeService : IService
{
    /// <summary>
    /// Changes the theme of the application.
    /// </summary>
    /// <param name="theme">The theme</param>
    void ChangeTheme(Theme theme);

    /// <summary>
    /// Changes the accent color of the application.
    /// </summary>
    /// <param name="theme">The accent color</param>
    void ChangeAccentColor(AccentColor accentColor);
}
