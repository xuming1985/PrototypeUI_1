using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace PrototypeUI_1.ViewModel
{
    public class AlertViewModel : PopViewModel
    {
        private string _title;
        private string _message;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }

        public RelayCommand ConfirmCommand { get; set; }

        public AlertViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm()
        {

        }
    }
}
