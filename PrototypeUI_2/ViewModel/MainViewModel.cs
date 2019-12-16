using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PrototypeUI_2.Core;
using System.Collections.Generic;
using System.Linq;

namespace PrototypeUI_2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentPartViewModel;
        private Dictionary<string,ViewModelBase> _partViewModels;

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
        }

        private void Navigate(string node)
        {
            if (_partViewModels.ContainsKey(node))
            {
                CurrentPartViewModel = _partViewModels[node];
            }
        }
    }
}