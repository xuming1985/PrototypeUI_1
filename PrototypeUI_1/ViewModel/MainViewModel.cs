﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PrototypeUI_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrototypeUI_1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isLogin;
        private PartViewModel _currentViewModel;
        private List<PartViewModel> _viewModels;

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

        public PartViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    RaisePropertyChanged("CurrentViewModel");
                }
            }
        }
        public LoginViewModel LoginVM { get; set; }
        public RelayCommand<TreeNodeModel> NavigateCommand { get; set; }
        public ObservableCollection<TreeNodeModel> TreeNodeModels { get; set; }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            LoginVM.LoginSuccessed += new Action<bool>(LoginSuccessed);  
            NavigateCommand = new RelayCommand<TreeNodeModel>(Navigate);

            _viewModels = new List<PartViewModel>();
            _viewModels.Add(new PasswordUpdateViewModel() { Name = "PasswordUpdateViewModel" });
            _viewModels.Add(new UserAddViewModel() { Name = "UserAddViewModel" });
            _viewModels.Add(new UserUpdateViewModel() { Name = "UserUpdateViewModel" });
            _viewModels.Add(new UserDeleteViewModel() { Name = "UserDeleteViewModel" });
            _viewModels.Add(new DesignInputViewModel() { Name = "DesignInputViewModel" });
            _viewModels.Add(new DesignPreViewModel() { Name = "DesignPreViewModel" });
            _viewModels.Add(new DrawingOutputViewModel() { Name = "DrawingOutputViewModel" });
            _viewModels.Add(new BomReportViewModel() { Name = "BomReportViewModel" });
            _viewModels.Add(new PartComponentMgmtViewModel() { Name = "PartComponentMgmtViewModel" });
            _viewModels.Add(new StandardComponentMgmtViewModel() { Name = "StandardComponentMgmtViewModel" });
            _viewModels.Add(new AboutViewModel() { Name = "AboutViewModel" });
            _viewModels.Add(new HelpViewModel() { Name = "HelpViewModel" });

            TreeNodeModels = new ObservableCollection<TreeNodeModel>
            {
                new TreeNodeModel()
                {
                    Name = "系统设置",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/setting.png",
                    FontSize = 18,
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="密码修改",Tag = "PasswordUpdateViewModel"},
                        new TreeNodeModel(){Name="新建用户",Tag = "UserAddViewModel"},
                        new TreeNodeModel(){Name="修改用户",Tag = "UserUpdateViewModel"},
                        new TreeNodeModel(){Name="删除用户",Tag = "UserDeleteViewModel"},
                    }
                },
                new TreeNodeModel()
                {
                    Name = "设计输入",
                    Tag = "DesignInputViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/input.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "设计预览",
                    Tag = "DesignPreViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/preview.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "设计输出",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/output.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0),
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="工程图输出",Tag = "DrawingOutputViewModel"},
                        new TreeNodeModel(){Name="BOM报表",Tag = "BomReportViewModel"}
                    }
                },
                new TreeNodeModel()
                {
                    Name = "数据管理",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/data.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0),
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="零部件管理",Tag = "PartComponentMgmtViewModel"},
                        new TreeNodeModel(){Name="标准件管理",Tag = "StandardComponentMgmtViewModel"}
                    }
                },
                new TreeNodeModel()
                {
                    Name = "帮助",
                    Tag = "HelpViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/help.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "关于",
                    Tag = "AboutViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/about.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                }
            };
        }

        private void LoginSuccessed(bool isAdmin)
        {
            Islogin = true;
        }

        private void Navigate(TreeNodeModel node)
        {
            var vm = _viewModels.FirstOrDefault(o => o.Name == node.Tag);
            if (vm != null)
            {
                CurrentViewModel = vm;
            }
        }
    }
}
