using GalaSoft.MvvmLight;
using PrototypeUI_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

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

            return viewModels;
        }
    }
}
