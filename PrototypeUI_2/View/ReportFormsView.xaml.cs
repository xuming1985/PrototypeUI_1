using CefSharp;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace PrototypeUI_2.View
{
    /// <summary>
    /// ReportFormsView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportFormsView : UserControl
    {
        public ReportFormsView()
        {
            InitializeComponent();

            BrowserSettings browserSettings = new BrowserSettings
            {
                FileAccessFromFileUrls = CefState.Enabled,
                UniversalAccessFromFileUrls = CefState.Enabled,
                ApplicationCache = CefState.Enabled,
            };
            chartbrowser.BrowserSettings = browserSettings;

            Loaded += ReportFormsView_Loaded;
        }

        private void ReportFormsView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Messenger.Default.Send(chartbrowser, "WebBrowser");
        }
    }
}
