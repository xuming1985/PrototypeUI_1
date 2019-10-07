using GalaSoft.MvvmLight.Command;
using PrototypeService;
using PrototypeService.Entity;

namespace PrototypeUI_1.ViewModel
{
    public class UserAddViewModel : PartViewModel
    {
        private string _jobNumber = "admin";
        private string _password = "admin";
        private readonly MockDataService _mockDataService;

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

        public RelayCommand ConfirmCommand { get; set; }

        public UserAddViewModel()
        {
            _mockDataService = new MockDataService();
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm()
        {
            var account = new Account();
            account.JobNumber = JobNumber;
            account.Password = Password;

            int result = _mockDataService.AddUser(account);
            if (result == 1)
            {
                //成功
            }
            else if(result == 0)
            {
                //工号已存在
            }
            else
            {
                //系统错误
            }
        }
    }
}
