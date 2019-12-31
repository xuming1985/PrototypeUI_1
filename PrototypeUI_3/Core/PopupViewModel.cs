using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace PrototypeUI_3.Core
{
    public class PopupViewModel : ViewModelBase
    {
        public RelayCommand<string> ExecuteCommand { get; set; }

        public PopupViewModel()
        {
            ExecuteCommand = new RelayCommand<string>(Execute);
        }

        private void Execute(string category)
        {
            Messenger.Default.Send(category, "PopupClose");
        }
    }
}
