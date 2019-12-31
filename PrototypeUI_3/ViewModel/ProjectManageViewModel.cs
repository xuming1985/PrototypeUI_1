using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PrototypeUI_3.Core;
using PrototypeUI_3.Model;
using System;
using System.Collections.ObjectModel;

namespace PrototypeUI_3.ViewModel
{
    public class ProjectManageViewModel: ComponentViewModel
    {
        public ObservableCollection<ProjectModel> Projects { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeletePatchCommand { get; set; }

        public ProjectManageViewModel()
        {
            Projects = new ObservableCollection<ProjectModel>();

            AddCommand = new RelayCommand(AddExecute);
            DeletePatchCommand = new RelayCommand(DeletePatchExecute);
        }

        public override void Init()
        {
            Random r = new Random();
            for (int i = 1; i <= 49; i++)
            {
                var model = new ProjectModel();
                model.Index = i + 1;
                model.Name = "2D图纸尺寸计算软件";
                model.Remark = "注意事项1注意事项2注意事项3注意事项4";
                model.HaveDrawing = "有";
                model.LayoutCount = r.Next(0, 6);
                Projects.Add(model);
            }
        }
   
        public void AddExecute()
        {
            OperateMessage<object> message = new OperateMessage<object>();
            message.OperateType = CellOperateType.AddProject;
            message.Data = null;
            Messenger.Default.Send(message, "CellOperate");
        }

        public void DeletePatchExecute()
        {

        }
    }
}
