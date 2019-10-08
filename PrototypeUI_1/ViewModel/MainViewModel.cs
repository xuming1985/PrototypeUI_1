using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PrototypeUI_1.Core;
using PrototypeUI_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrototypeUI_1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isPop;
        private bool _isLogin;
        private PopViewModel _currentPopViewModel;
        private PartViewModel _currentPartViewModel;
        private List<PopViewModel> _popViewModels;
        private List<PartViewModel> _partViewModels;

        //控制弹框是否显示
        public bool IsPop
        {
            get { return _isPop; }
            set
            {
                if (_isPop != value)
                {
                    _isPop = value;
                    RaisePropertyChanged("IsPop");
                }
            }
        }

        //控制登录页是否显示
        public bool Islogin
        {
            get { return _isLogin; }
            set
            {
                if (_isLogin != value)
                {
                    _isLogin = value;
                    RaisePropertyChanged("Islogin");
                }
            }
        }

        /// <summary>
        /// 当前弹出页
        /// </summary>
        public PopViewModel CurrentPopViewModel
        {
            get { return _currentPopViewModel; }
            set
            {
                if (_currentPopViewModel != value)
                {
                    _currentPopViewModel = value;
                    RaisePropertyChanged("CurrentPopViewModel");
                }
            }
        }

        /// <summary>
        /// 当前功能页——VM
        /// </summary>
        public PartViewModel CurrentPartViewModel
        {
            get { return _currentPartViewModel; }
            set
            {
                if (_currentPartViewModel != value)
                {
                    _currentPartViewModel = value;
                    RaisePropertyChanged("CurrentPartViewModel");
                }
            }
        }

        /// <summary>
        /// 登录页面数据——VM
        /// </summary>
        public LoginViewModel LoginVM { get; set; }

        public RelayCommand<TreeNodeModel> NavigateCommand { get; set; }
        public ObservableCollection<TreeNodeModel> TreeNodeModels { get; set; }

        public MainViewModel()
        {
            _popViewModels = Utils.GetPopViewModels();
            _partViewModels = Utils.GetPartViewModels();
            TreeNodeModels = Utils.GetTreeNodeModels();

            LoginVM = new LoginViewModel();
            LoginVM.LoginSuccessed += new Action<bool>(LoginSuccessed);  
            NavigateCommand = new RelayCommand<TreeNodeModel>(Navigate);

            Messenger.Default.Register<PopMessageModel>(this, "Pop", ShowPop);
        }

        /// <summary>
        /// 登录成功后，改变标记是否登录
        /// </summary>
        /// <param name="isAdmin"></param>
        private void LoginSuccessed(bool isAdmin)
        {
            Islogin = true;
        }

        /// <summary>
        /// 点击左侧导航菜单，显示不同的页面
        /// </summary>
        /// <param name="node"></param>
        private void Navigate(TreeNodeModel node)
        {
            var vm = _partViewModels.FirstOrDefault(o => o.Name == node.Tag);
            if (vm != null)
            {
                CurrentPartViewModel = vm;
            }
        }

        /// <summary>
        /// 弹出弹框
        /// </summary>
        /// <param name="connet"></param>
        private void ShowPop(PopMessageModel model)
        {
            if (model != null)
            {
                IsPop = true;
                CurrentPopViewModel = _popViewModels.FirstOrDefault(o=>o.Name == model.Token);
                Messenger.Default.Send(model, model.Token);
            }
            else
            {
                IsPop = false;
            }
           
        }
    }
}
