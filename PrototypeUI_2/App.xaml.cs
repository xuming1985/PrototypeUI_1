using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Windows;

namespace PrototypeUI_2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

            string cachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache");

            if (Directory.Exists(cachePath))
            {
                if (Directory.Exists(Path.Combine(cachePath, "Cache")))
                    Directory.Delete(Path.Combine(cachePath, "Cache"), true);
                if (Directory.Exists(Path.Combine(cachePath, "GPUCache")))
                    Directory.Delete(Path.Combine(cachePath, "GPUCache"), true);
            }

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = cachePath,
            };
            //settings.CefCommandLineArgs.Add("--js-flags", "--max_old_space_size=16384");
            settings.CefCommandLineArgs.Add("disable-application-cache", "0");
            settings.CefCommandLineArgs.Add("disable-session-storage", "1");
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");

            //安全证书
            settings.CefCommandLineArgs.Add("--ignore-urlfetcher-cert-requests", "1");
            settings.CefCommandLineArgs.Add("--ignore-certificate-errors", "1");

            CefSharpSettings.SubprocessExitIfParentProcessClosed = true;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
        }
    }
}
