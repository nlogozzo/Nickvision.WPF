using Nickvision.WPF.Extensions;
using Nickvision.WPF.Models;
using Nickvision.WPF.MVVM;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nickvision.WPF.Update;

/// <summary>
/// An update manager.
/// </summary>
public class Updater
{
    private readonly AppInfo _appInfo;
    private readonly HttpClient _httpClient;
    private readonly Uri _linkToConfig;
    private UpdateConfig? _updateConfig;
    private bool _updateAvailable;

    /// <summary>
    /// Whether or not an update is available.
    /// </summary>
    public bool UpdateAvailable => _updateAvailable && _updateConfig != null;
    /// <summary>
    /// The version provided by the update, if available.
    /// </summary>
    public Version? LatestVersion => _updateConfig == null ? null : new Version(_updateConfig.LatestVersion);
    /// <summary>
    /// The changelog of the update, if available.
    /// </summary>
    public string? Changelog => _updateConfig?.Changelog;

    /// <summary>
    /// Constructs an Updater.
    /// </summary>
    /// <param name="appInfo">The AppInfo for the running application</param>
    /// <param name="httpClient">The HttpClient</param>
    /// <param name="linkToConfig">The link to the UpdateConfig file online</param>
    public Updater(AppInfo appInfo, HttpClient httpClient, Uri linkToConfig)
    {
        _appInfo = appInfo;
        _httpClient = httpClient;
        _linkToConfig = linkToConfig;
        _updateConfig = null;
        _updateAvailable = false;
    }

    /// <summary>
    /// Checks if an update is available.
    /// </summary>
    /// <returns>Whether or not an update is available</returns>
    public async Task<bool> CheckForUpdatesAsync()
    {
        _updateConfig = await UpdateConfig.LoadFromWebAsync(_appInfo, _httpClient, _linkToConfig);
        if (_updateConfig != null && LatestVersion > _appInfo.Version)
        {
            _updateAvailable = true;
        }
        return UpdateAvailable;
    }

    /// <summary>
    /// Downloads and installs the update for the application.
    /// </summary>
    /// <param name="window">The MainWindow</param>
    /// <returns>True if the update was successful. Else, false</returns>
    public async Task<bool> UpdateAsync(ICloseable window)
    {
        if (!UpdateAvailable)
        {
            return false;
        }
        var dataDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}Nickvision{Path.DirectorySeparatorChar}{_appInfo.Name}";
        var pathToDownload = $"{dataDir}{Path.DirectorySeparatorChar}Setup.exe";
        var downloadSuccess = await _httpClient.DownloadFileAsync(new Uri(_updateConfig!.LinkToSetup), pathToDownload);
        if (!downloadSuccess)
        {
            return false;
        }
        var proInstaller = new Process();
        proInstaller.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        proInstaller.StartInfo.FileName = pathToDownload;
        proInstaller.StartInfo.UseShellExecute = true;
        proInstaller.StartInfo.Verb = "runas";
        proInstaller.Start();
        window.Close();
        return true;
    }
}