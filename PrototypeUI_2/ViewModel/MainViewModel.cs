using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PrototypeUI_2.Core;
using PrototypeUI_2.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PrototypeUI_2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Visibility _popVisibility = Visibility.Collapsed;
        private Visibility _loginVisibility = Visibility.Visible;
        private Visibility _returnVisibility = Visibility.Collapsed;
        private ViewModelBase _currentPopVm;
        private ComponentViewModel _currentPartViewModel;
        private Dictionary<string, ComponentViewModel> _partViewModels;

        public Visibility PopVisibility
        {
            get { return _popVisibility; }
            set
            {
                if (_popVisibility != value)
                {
                    _popVisibility = value;
                    RaisePropertyChanged("PopVisibility");
                }
            }
        }
        public Visibility LoginVisibility
        {
            get { return _loginVisibility; }
            set
            {
                if (_loginVisibility != value)
                {
                    _loginVisibility = value;
                    RaisePropertyChanged("LoginVisibility");
                }
            }
        }
        public Visibility ReturnVisibility
        {
            get { return _returnVisibility; }
            set
            {
                if (_returnVisibility != value)
                {
                    _returnVisibility = value;
                    RaisePropertyChanged("ReturnVisibility");
                }
            }
        }

        public LoginViewModel LoginVM { get; set; }
        public ViewModelBase CurrentPopVm
        {
            get { return _currentPopVm; }
            set
            {
                if (_currentPopVm != value)
                {
                    _currentPopVm = value;
                    RaisePropertyChanged("CurrentPopVm");
                }
            }
        }

        /// <summary>
        /// 当前功能页——VM
        /// </summary>
        public ComponentViewModel CurrentPartViewModel
        {
            get { return _currentPartViewModel; }
            set
            {
                if (_currentPartViewModel != null)
                {
                    _currentPartViewModel.Dispose();
                }
                
                if (_currentPartViewModel != value)
                {
                    _currentPartViewModel = value;
                    RaisePropertyChanged("CurrentPartViewModel");
                    _currentPartViewModel.Init();
                    if (_currentPartViewModel.Parent != null)
                    {
                        ReturnVisibility = Visibility.Visible;
                    }
                    else
                    {
                        ReturnVisibility = Visibility.Collapsed;
                    }
                }
            }
        }

        public RelayCommand<string> NavigateCommand { get; set; }
        public RelayCommand<string> ReturnCommand { get; set; }
        public RelayCommand<string> ExecuteCommand { get; set; }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            LoginVM.LoginSuccess += Init;
           
            NavigateCommand = new RelayCommand<string>(Navigate);
            ReturnCommand = new RelayCommand<string>(ReturnNavigate);
            ExecuteCommand = new RelayCommand<string>(Execute);

            Messenger.Default.Register<PopMessageModel>(this, "Pop", ShowPop);
            Messenger.Default.Register<string>(this, "PopClose", PopClose);
        }

        /// <summary>
        /// 登录成功后初始化主页面
        /// </summary>
        private void Init()
        {
            LoginVisibility = Visibility.Collapsed;

            _partViewModels = Utils.GetPartViewModels();
            CurrentPartViewModel = _partViewModels.FirstOrDefault().Value;
        }

        private void Navigate(string node)
        {
            if (_partViewModels.ContainsKey(node))
            {
                CurrentPartViewModel = _partViewModels[node];
            }
        }

        private void ReturnNavigate(string node)
        {
            if (CurrentPartViewModel != null)
            {
                CurrentPartViewModel = CurrentPartViewModel.Parent;
            }
        }

        private void ShowPop(PopMessageModel model)
        {
            if (model.Data == null)
            {
                if(model.Category == "ProjectAdd")
                {
                    CurrentPopVm = new ProjectAddViewModel();
                    PopVisibility = Visibility.Visible;
                }
            }
            else
            {
                if (model.Data is ProjectModel)
                {
                    if (model.Category == "1")
                    {
                        CurrentPopVm = new EntrustingPartViewModel();
                        PopVisibility = Visibility.Visible;
                    }
                    else if (model.Category == "2")
                    {
                        CurrentPopVm = new DetectionPartViewModel();
                        PopVisibility = Visibility.Visible;
                    }
                    else if (model.Category == "3")
                    {
                       
                    }
                    else if (model.Category == "4")
                    {
                        Navigate("CheckTask");
                    }
                }
                else if (model.Data is ProjectStatisticsModel)
                {
                    if (model.Category == "1")
                    {
                        CurrentPopVm = new DeviceInfoViewModel();
                        PopVisibility = Visibility.Visible;
                    }
                    else if (model.Category == "3")
                    {
                       
                    }
                    else if (model.Category == "4")
                    {
                        Navigate("CheckTask");
                    }
                }
            }
        }

        private void PopClose(string message)
        {
            PopVisibility = Visibility.Collapsed;
            CurrentPopVm = null;
        }

        private void Execute(string content)
        {
            if(content == "logout")
            {
                LoginVisibility = Visibility.Visible;
            }
            else if (content == "person")
            {

            }
        }
    }
}