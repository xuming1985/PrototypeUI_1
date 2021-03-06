﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PrototypeUI_1.Model;

namespace PrototypeUI_1.ViewModel
{
    public class AlertViewModel : PopViewModel
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        public RelayCommand ConfirmCommand { get; set; }

        public AlertViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);

            Messenger.Default.Register<PopMessageModel>(this, GetType().Name, ShowMessage);
        }

        /// <summary>
        /// 知道了 按钮， 关闭弹框
        /// </summary>
        private void Confirm()
        {
            Messenger.Default.Send<PopMessageModel>(null, PopToken);
        }

        /// <summary>
        /// 显示弹出消息
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(PopMessageModel model)
        {
            Message = model.Message;
        }
    }
}
