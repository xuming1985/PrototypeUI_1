using GalaSoft.MvvmLight.Command;
using PrototypeService;
using PrototypeUI_1.Core;
using PrototypeUI_1.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrototypeUI_1.ViewModel
{
    public class UserDeleteViewModel : PartViewModel
    {
        private readonly MockDataService _mockDataService;

        public RelayCommand ShowCommand { get; set; }
        
        public RelayCommand DeleteCommand { get; set; }
        public ObservableCollection<AccountModel> Accounts { get; set; }

        public UserDeleteViewModel()
        {
            _mockDataService = new MockDataService();

            ShowCommand = new RelayCommand(Show);
            DeleteCommand = new RelayCommand(Delete);
            Accounts = new ObservableCollection<AccountModel>();
        }

        /// <summary>
        /// 显示所有账号
        /// </summary>
        private void Show()
        {
            Accounts.Clear();
            var accounts = _mockDataService.GetAccounts();
            foreach(var a in accounts)
            {
                var model = new AccountModel();
                model.JobNumber = a.JobNumber;
                Accounts.Add(model);
            }
        }

        /// <summary>
        /// 删除选中账号
        /// </summary>
        private void Delete()
        {
            var selects = Accounts.Where(o=>o.IsSelected == true);
            foreach(var model in selects)
            {
                if(model.JobNumber!= Utils.CurrentAccount.JobNumber)
                {
                    _mockDataService.DeleteUser(model.JobNumber);
                }
            }
            Show();
        }
    }
}
