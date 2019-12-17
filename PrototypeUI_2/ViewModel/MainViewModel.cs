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
        private ViewModelBase _currentPopVm;
        private ViewModelBase _currentPartViewModel;
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
        public ViewModelBase CurrentPartViewModel
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

        public RelayCommand<string> NavigateCommand { get; set; }

        public MainViewModel()
        {
            _partViewModels = Utils.GetPartViewModels();
            _currentPartViewModel = _partViewModels.FirstOrDefault().Value;
            NavigateCommand = new RelayCommand<string>(Navigate);

            Messenger.Default.Register<PopMessageModel>(this, "Pop", ShowPop);
            Messenger.Default.Register<string>(this, "PopClose", PopClose);
        }

        private void Navigate(string node)
        {
            if (_partViewModels.ContainsKey(node))
            {
                CurrentPartViewModel = _partViewModels[node];
            }
        }

        private void ShowPop(PopMessageModel model)
        {
            if (model.Data == null)
            {
                if(model.Category == "ProjectAdd")
                {
                    CurrentPopVm = new ProjectAddViewModel();
                }
            }
            else
            {
                if (model.Data is ProjectModel)
                {
                    if (model.Category == "1")
                    {
                        CurrentPopVm = new EntrustingPartViewModel();
                    }
                    else if (model.Category == "2")
                    {
                        CurrentPopVm = new DetectionPartViewModel();
                    }
                    else if (model.Category == "3")
                    {
                       
                    }
                    else if (model.Category == "4")
                    {
                        
                    }
                }
                else if (model.Data is ProjectStatisticsModel)
                {
                    if (model.Category == "1")
                    {
                        CurrentPopVm = new DeviceInfoViewModel();
                    }
                    else if (model.Category == "3")
                    {
                       
                    }
                    else if (model.Category == "4")
                    {
                       
                    }
                }
            }

            PopVisibility = Visibility.Visible;

        }

        private void PopClose(string message)
        {
            PopVisibility = Visibility.Collapsed;
            CurrentPopVm = null;
        }
    }
}