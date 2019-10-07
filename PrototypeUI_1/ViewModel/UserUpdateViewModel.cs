using GalaSoft.MvvmLight.Command;
using PrototypeService;

namespace PrototypeUI_1.ViewModel
{
    public class UserUpdateViewModel : PartViewModel
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

        public RelayCommand ConfirmCommand { get; set; }

        public UserUpdateViewModel()
        {
            _mockDataService = new MockDataService();
            ConfirmCommand = new RelayCommand(Confirm);

        }

        private void Confirm()
        {
            int result = _mockDataService.UpdateUser(JobNumber, Password);
            if (result == 1)
            {
                //成功
            }
            else if (result == 0)
            {
                //工号不存在
            }
            else
            {
                //系统错误
            }
        }
    }
}
