using Nickvision.WPF.Extensions;
using Nickvision.WPF.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nickvision.WPF.Update;

/// <summary>
/// Represents configuration settings for an update.
/// </summary>
public class UpdateConfig
{
    /// <summary>
    /// The version of the update.
    /// </summary>
    public string LatestVersion { get; set; }
    /// <summary>
    /// The changelog of the update.
    /// </summary>
    public string Changelog { get; set; }
    /// <summary>
    /// The link to the setup file.
    /// </summary>
    public string LinkToSetup { get; set; }

    /// <summary>
    /// Constructs an UpdateConfig.
    /// </summary>
    public UpdateConfig()
    {
        LatestVersion = "";
        Changelog = "";
        LinkToSetup = "";
    }

    /// <summary>
    /// Parses an UpdateConfig object from the provided link.
    /// </summary>
    /// <param name="appInfo">The AppInfo of the running application</param>
    /// <param name="httpClient">The HttpClient</param>
    /// <param name="linkToConfig">The link to the UpdateConfig file online</param>
    /// <returns>An UpdateConfig object parsed from the provided file link. Null if unable to parse</returns>
    public static async Task<UpdateConfig?> LoadFromWebAsync(AppInfo appInfo, HttpClient httpClient, Uri linkToConfig)
    {
        var dataDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}Nickvision{Path.DirectorySeparatorChar}{appInfo.Name}";
        var pathToDownload = $"{dataDir}{Path.DirectorySeparatorChar}UpdateConfig.json";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        try
        {
            await httpClient.DownloadFileAsync(linkToConfig, pathToDownload);
            var json = File.ReadAllText(pathToDownload);
            return JsonSerializer.Deserialize<UpdateConfig>(json);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Saves an UpdateConfig object as a json file to the desktop.
    /// </summary>
    /// <returns>The path of the saved UpdateConfig file</returns>
    public string SaveToDisk()
    {
        var pathToSave = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}UpdateConfig.json";
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(pathToSave, json);
        return pathToSave;
    }
}