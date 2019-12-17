using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace PrototypeUI_2.Model
{
    public class ProjectStatisticsModel
    {
        public bool IsSelected { get; set; }
        public string SerialNo { get; set; }
        public string Name { get; set; }
        public int Road { get; set; }
        public int Pipe { get; set; }
        public double CheckMile { get; set; }
        public double ReadedMile { get; set; }
        public double CheckedMile { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime PlanCompleteDate { get; set; }
        public string EvaluationStandard { get; set; }
        public string Status { get; set; }
        public int Progress { get; set; }

        public RelayCommand<string> PopViewCommand { get; set; }

        public ProjectStatisticsModel()
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
