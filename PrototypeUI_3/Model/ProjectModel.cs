using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace PrototypeUI_3.Model
{
    public class ProjectModel
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public string HaveDrawing { get; set; }

        public int LayoutCount { get; set; }

        public RelayCommand<string> CellCommand { get; set; }

        public ProjectModel()
        {
            CellCommand = new RelayCommand<string>(CellOperate);
        }

        private void CellOperate(string category)
        {
            OperateMessage<object> message = new OperateMessage<object>();
            message.OperateType =(CellOperateType)Enum.Parse(typeof(CellOperateType), category);
            message.Data = this;
            Messenger.Default.Send(message, "CellOperate");
        }
    }
}
