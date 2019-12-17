using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace PrototypeUI_2.Model
{
    public class ProjectModel
    {
        public bool IsSelected { get; set; }
        public string SerialNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EntrustingPart { get; set; }
        public string DetectionPart { get; set; }
        //批准人
        public string Approver { get; set; }
        //审定人
        public string Verifier { get; set; }
        //审核人
        public string Auditor { get; set; }
        //校核人
        public string Checker { get; set; }
        //编写人
        public string Author { get; set; }
        //工程管理员
        public string Administrator { get; set; }
        public string InnerOperator { get; set; }
        public string OutterOperator { get; set; }

        public DateTime CreateTime { get; set; }

        public RelayCommand<string> PopViewCommand { get; set; }

        public ProjectModel()
        {
            PopViewCommand = new RelayCommand<string>(PopView);
        }

        private void PopView(string category)
        {
            PopMessageModel message = new PopMessageModel();
            message.Category = category;
            message.Data = this;
            Messenger.Default.Send(message, "Pop");
        }
    }
}
