using PrototypeUI_2.Core;
using PrototypeUI_2.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrototypeUI_2.ViewModel
{
    public class SystemManageViewModel : ComponentViewModel
    {
        private PagingViewModel _userPaging;

        public PagingViewModel UserPagingVM
        {
            get { return _userPaging; }
            set
            {
                if (_userPaging != value)
                {
                    _userPaging = value;
                    RaisePropertyChanged("UserPagingVM");
                }
            }
        }
        public List<TreeItemModel> Departments { get; set; }

        public ObservableCollection<UserModel> Users { get; set; }

        public SystemManageViewModel()
        {
            UserPagingVM = new PagingViewModel() { PageCount = 10};
            Users = new ObservableCollection<UserModel>();
        }

        public override void Init()
        {
            base.Init();

            Departments = MockService.GetDepartments();

            var resultUser = MockService.GetUsers(UserPagingVM.Page, UserPagingVM.PageCount);
            UserPagingVM.Init(resultUser.Total);
            foreach (var item in resultUser.Data)
            {
                Users.Add(item);
            }
        }
    }
}
