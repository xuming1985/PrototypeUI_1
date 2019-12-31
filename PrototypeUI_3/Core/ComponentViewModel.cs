using GalaSoft.MvvmLight;

namespace PrototypeUI_3.Core
{
    public class ComponentViewModel : ViewModelBase
    {
        public ComponentViewModel Parent { get; set; }

        public virtual void Init()
        {

        }

        public virtual void Dispose()
        {

        }
    }
}
