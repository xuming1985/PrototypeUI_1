﻿using GalaSoft.MvvmLight;

namespace PrototypeUI_2.ViewModel
{
    public class ComponentViewModel : ViewModelBase
    {
        public ComponentViewModel Parent{ get; set; }

        public virtual void Init()
        {

        }

        public virtual void Dispose()
        {

        }
    }
}
