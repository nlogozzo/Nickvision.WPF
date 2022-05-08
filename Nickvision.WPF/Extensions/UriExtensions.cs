using System;
using System.Diagnostics;

namespace Nickvision.WPF.Extensions;

/// <summary>
/// Extension methods for Uri.
/// </summary>
public static class UriExtensions
{
    /// <summary>
    /// Opens a Uri in the default browser.
    /// </summary>
    /// <param name="uri">The Uri to open</param>
    public static void OpenInBrowser(this Uri uri)
    {
        var url = uri.ToString();
        url.Replace("&", "^&");
        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
    }
}
