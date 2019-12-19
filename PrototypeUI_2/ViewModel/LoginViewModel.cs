using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PrototypeUI_2.Core;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PrototypeUI_2.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private string _account = "";
        private string _password = "";
        private bool _isAutoLogin;
        private string _autoLoginConfigFileName = "autologin.x";

        public string Account
        {
            get { return _account; }
            set
            {
                if (_account != value)
                {
                    _account = value;
                    RaisePropertyChanged("Account");
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        public bool IsAutoLogin
        {
            get { return _isAutoLogin; }
            set
            {
                if (_isAutoLogin != value)
                {
                    _isAutoLogin = value;
                    RaisePropertyChanged("IsAutoLogin");
                }
            }
        }

        public Action LoginSuccess;
        public RelayCommand<string> ExecuteCommand { get; set; }

        public LoginViewModel()
        {
            ExecuteCommand = new RelayCommand<string>(Execute);

            Task.Factory.StartNew(new Action(() =>
            {
                InitConfig();
            })); 
        }

        private void InitConfig()
        {
            string configFile = $"{Utils.ConfigFolder}{_autoLoginConfigFileName}";
            if (File.Exists(configFile))
            {
                IsAutoLogin = true;
                string content = Utils.ReadConfig(_autoLoginConfigFileName);
                Account = content.Split('_')[0];
                Password = content.Split('_')[1];
                Thread.Sleep(1000);
                LoginSuccess?.Invoke();
            }
        }

        private void Execute(string content)
        {
            if(content == "login")
            {
                LoginSuccess?.Invoke();
                string account_password = $"{Account}_{Password}";
                if (IsAutoLogin)
                {
                    Utils.WriteConfig(account_password, _autoLoginConfigFileName);
                }
                else
                {
                    string configFile = $"{Utils.ConfigFolder}{_autoLoginConfigFileName}";
                    if (File.Exists(configFile))
                    {
                        File.Delete(configFile);
                    }
                }
            }
            else if (content == "forget")
            {

            }
        }

    }
}
