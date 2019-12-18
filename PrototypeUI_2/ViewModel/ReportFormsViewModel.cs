using CefSharp;
using CefSharp.Wpf;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace PrototypeUI_2.ViewModel
{
    public class ReportFormsViewModel : ComponentViewModel
    {
        private string _host = "";
        private string _address;
        private ChromiumWebBrowser _webBrowser;

        public RelayCommand<string> SwitchCommand { get; set; }

        public ReportFormsViewModel()
        {
            _host = AppDomain.CurrentDomain.BaseDirectory;

            SwitchCommand = new RelayCommand<string>(SwitchExecute);

            Messenger.Default.Register<ChromiumWebBrowser>(this, "WebBrowser", ImportWebBrowser);
        }

        private void ImportWebBrowser(ChromiumWebBrowser webBrowser)
        {
            if (string.IsNullOrWhiteSpace(_address))
            {
                _address = $"{_host}Html\\demo1.html";
            }
            
            _webBrowser = webBrowser;
            _webBrowser.Address = _address;
            _webBrowser.RegisterJsObject("wpfClient", this, new BindingOptions() { CamelCaseJavascriptNames = false });
        }

        private void SwitchExecute(string content)
        {
            _address = $"{_host}Html\\{content}.html";
            _webBrowser.Address = _address;
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Dispose()
        {
            base.Dispose();
            _webBrowser.Dispose();
        }
    }
}
