using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nickvision.WPF.Extensions;

/// <summary>
/// Extension methods for HttpClient.
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Downloads a file from the url and saves it to the path.
    /// </summary>
    /// <param name="httpClient">The HttpClient to use</param>
    /// <param name="uri">The url of the file to download</param>
    /// <param name="path">The path of where to save the downloaded file</param>
    /// <returns>True if the file was downloaded successfully, else false</returns>
    public static async Task<bool> DownloadFileAsync(this HttpClient httpClient, Uri uri, string path)
    {
        try
        {
            var bytes = await httpClient.GetByteArrayAsync(uri);
            File.WriteAllBytes(path, bytes);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
