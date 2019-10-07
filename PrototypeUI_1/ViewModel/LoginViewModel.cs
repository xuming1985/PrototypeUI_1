using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PrototypeService;
using PrototypeUI_1.Core;
using System;
using System.Windows;

namespace PrototypeUI_1.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _jobNumber = "admin";
        private string _password = "admin";
        private MockDataService _mockDataService;

        public string JobNumber
        {
            get { return _jobNumber; }
            set
            {
                if (_jobNumber != value)
                {
                    _jobNumber = value;
                    RaisePropertyChanged("JobNumber");
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

        public Action<bool> LoginSuccessed;
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }

        public LoginViewModel()
        {
            _mockDataService = new MockDataService();

            LoginCommand = new RelayCommand(Login);
            ExitCommand = new RelayCommand(Exit);
        }

        private void Login()
        {
            Utils.CurrentAccount = _mockDataService.Login(JobNumber, Password);
            if (Utils.CurrentAccount != null)
            {
                LoginSuccessed?.Invoke(Utils.CurrentAccount.IsAdmin);
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown(-1);
        }
    }
}
