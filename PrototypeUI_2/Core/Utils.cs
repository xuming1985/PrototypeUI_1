using PrototypeUI_2.ViewModel;
using System.Collections.Generic;

namespace PrototypeUI_2.Core
{
    public static class Utils
    {
        /// <summary>
        /// 得到所以功能页VM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, ComponentViewModel> GetPartViewModels()
        {
            var viewModels = new Dictionary<string, ComponentViewModel>();
            viewModels.Add("ProjectManage", new ProjectManageViewModel());
            viewModels.Add("ReportForms", new ReportFormsViewModel());
            viewModels.Add("InformationManage", new InformationManageViewModel());
            viewModels.Add("SystemManage", new SystemManageViewModel());
            viewModels.Add("CheckTask", new CheckTaskViewModel() { Parent = viewModels["ProjectManage"] });
            return viewModels;
        }
    }
}
