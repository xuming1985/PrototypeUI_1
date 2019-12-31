using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PrototypeUI_3.Core;
using PrototypeUI_3.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PrototypeUI_3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Visibility _popupVisibility = Visibility.Collapsed;
        private Visibility _returnVisibility = Visibility.Collapsed;
        private ViewModelBase _currentPopupVm;
        private ComponentViewModel _currentPartViewModel;
        private Dictionary<string, ComponentViewModel> _partViewModels;

        public Visibility PopupVisibility
        {
            get { return _popupVisibility; }
            set
            {
                if (_popupVisibility != value)
                {
                    _popupVisibility = value;
                    RaisePropertyChanged("PopupVisibility");
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

        public ViewModelBase CurrentPopupVm
        {
            get { return _currentPopupVm; }
            set
            {
                if (_currentPopupVm != value)
                {
                    _currentPopupVm = value;
                    RaisePropertyChanged("CurrentPopupVm");
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
                PrePartViewModelChanged();

                if (_currentPartViewModel != value)
                {
                    _currentPartViewModel = value;
                    RaisePropertyChanged("CurrentPartViewModel");
                    OnPartViewModelChanged();
                }
            }
        }

        public RelayCommand<string> NavigateCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }

        public RelayCommand<string> ExecuteCommand { get; set; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand<string>(Navigate);
            ReturnCommand = new RelayCommand(ReturnNavigate);
            ExecuteCommand = new RelayCommand<string>(Execute);

            Messenger.Default.Register<OperateMessage<object>>(this, "CellOperate", CellOperate);
            Messenger.Default.Register<OperateMessage<object>>(this, "Popup", PopupShow);
            Messenger.Default.Register<string>(this, "PopupClose", PopupClose);

            Init();
        }


        private void PrePartViewModelChanged()
        {
            if (CurrentPartViewModel != null)
            {
                CurrentPartViewModel.Dispose();
            }
        }

        private void OnPartViewModelChanged()
        {
            CurrentPartViewModel.Init();
            if (CurrentPartViewModel.Parent != null)
            {
                ReturnVisibility = Visibility.Visible;
            }
            else
            {
                ReturnVisibility = Visibility.Collapsed;
            }
        }

        private void Init()
        {
            _partViewModels = new Dictionary<string, ComponentViewModel>();
            _partViewModels.Add("ProjectManage", new ProjectManageViewModel());
            _partViewModels.Add("LayoutManage", new LayoutManageViewModel() { Parent = _partViewModels["ProjectManage"] });
            _partViewModels.Add("InventoryManage", new InventoryManageViewModel());
            CurrentPartViewModel = _partViewModels.FirstOrDefault().Value;
        }

        private void Navigate(string view)
        {
            if (_partViewModels.ContainsKey(view))
            {
                CurrentPartViewModel = _partViewModels[view];
            }
        }

        private void ReturnNavigate()
        {
            if (CurrentPartViewModel != null)
            {
                CurrentPartViewModel = CurrentPartViewModel.Parent;
            }
        }

        private void  Execute(string operate)
        {
            if(operate == "Close")
            {
                Application.Current.Shutdown(-1);
            }
        }

        private void CellOperate(OperateMessage<object> operateMessage)
        {
            if(operateMessage.OperateType == CellOperateType.NavigateLayout)
            {
                Navigate("LayoutManage");
            }
            else if (operateMessage.OperateType == CellOperateType.AddProject)
            {
                CurrentPopupVm = new ProjectEditViewModel();
                PopupVisibility = Visibility.Visible;
            }
        }

        private void PopupShow(OperateMessage<object> operateMessage)
        {

        }

        private void PopupClose(string message)
        {
            PopupVisibility = Visibility.Collapsed;
            CurrentPopupVm = null;
        }
    }
}