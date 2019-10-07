using GalaSoft.MvvmLight.Command;
using PrototypeService;
using PrototypeUI_1.Core;

namespace PrototypeUI_1.ViewModel
{
    public class PasswordUpdateViewModel : PartViewModel
    {
        private string _password;
        private string _passwordConfirm;
        private MockDataService _mockDataService;

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

        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set
            {
                if (_passwordConfirm != value)
                {
                    _passwordConfirm = value;
                    RaisePropertyChanged("PasswordConfirm");
                }
            }
        }

        public RelayCommand ConfirmCommand { get; set; }

        public PasswordUpdateViewModel()
        {
            _mockDataService = new MockDataService();
            ConfirmCommand = new RelayCommand(Confirm);
        }

        /// <summary>
        /// 页面确定按钮，执行内容
        /// </summary>
        private void Confirm()
        {
            if (Password != PasswordConfirm)
            {
                return;
            }


           int result =  _mockDataService.UpdateUser(Utils.CurrentAccount.JobNumber,Password);
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
