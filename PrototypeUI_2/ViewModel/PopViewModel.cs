using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace PrototypeUI_2.ViewModel
{
    public class PopViewModel : ViewModelBase
    {
        public RelayCommand<string> ExecuteCommand { get; set; }

        public PopViewModel()
        {
            ExecuteCommand = new RelayCommand<string>(Execute);
        }

        private void Execute(string category)
        {
            Messenger.Default.Send(category, "PopClose");
        }
    }
}
