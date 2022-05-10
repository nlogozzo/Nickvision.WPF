using System;

namespace Nickvision.WPF.Models;

/// <summary>
/// A model of the information of an application.
/// </summary>
public class AppInfo
{
    /// <summary>
    /// The name of the app.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The description of the app.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The version of the app.
    /// </summary>
    public Version Version { get; set; }
    /// <summary>
    /// The changelog of the running version app.
    /// </summary>
    public string Changelog { get; set; }
    /// <summary>
    /// The copyright of the app.
    /// </summary>
    public string Copyright { get; set; }

    /// <summary>
    /// Constructs a new AppInfo.
    /// </summary>
    /// <param name="name">The name of the app</param>
    /// <param name="description">The description of the app</param>
    /// <param name="version">The version of the app</param>
    /// <param name="changelog">The changelog of the running version app</param>
    /// <param name="copyright">The copyright of the app</param>
    public AppInfo(string name = "", string description = "", Version? version = null, string changelog = "", string copyright = "")
    {
        Name = name;
        Description = description;
        Version = version ?? new Version(0, 0, 0);
        Changelog = changelog;
        Copyright = copyright;
    }
}
