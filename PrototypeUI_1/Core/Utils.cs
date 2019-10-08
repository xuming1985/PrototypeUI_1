using PrototypeService.Entity;
using PrototypeUI_1.Model;
using PrototypeUI_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace PrototypeUI_1.Core
{
    public static class Utils
    {
        public static Account CurrentAccount { get; set; }

        /// <summary>
        /// 得到所有弹出框得VM
        /// </summary>
        /// <returns></returns>
        public static List<PopViewModel> GetPopViewModels()
        {
            var viewModels = new List<PopViewModel>();

            var types = Assembly.GetExecutingAssembly().GetTypes();
            var baseType = typeof(PopViewModel);
            foreach (var t in types)
            {
                if (t.BaseType == baseType)
                {
                    PopViewModel obj = Activator.CreateInstance(t) as PopViewModel;
                    obj.Name = t.Name;
                    viewModels.Add(obj);
                }
            }
            return viewModels;
        }

        /// <summary>
        /// 得到所以功能页VM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<PartViewModel> GetPartViewModels()
        {
            var viewModels = new List<PartViewModel>();

            var types = Assembly.GetExecutingAssembly().GetTypes();
            var baseType = typeof(PartViewModel);
            foreach (var t in types)
            {
                if (t.BaseType == baseType)
                {
                    PartViewModel obj = Activator.CreateInstance(t) as PartViewModel;
                    obj.Name = t.Name;
                    viewModels.Add(obj);
                }
            }
            return viewModels;
        }

        /// <summary>
        /// 得到所有当行菜单节点
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<TreeNodeModel> GetTreeNodeModels()
        {
            return new ObservableCollection<TreeNodeModel>
            {
                new TreeNodeModel()
                {
                    Name = "系统设置",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/setting.png",
                    FontSize = 18,
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="密码修改",Tag = "PasswordUpdateViewModel"},
                        new TreeNodeModel(){Name="新建用户",Tag = "UserAddViewModel"},
                        new TreeNodeModel(){Name="修改用户",Tag = "UserUpdateViewModel"},
                        new TreeNodeModel(){Name="删除用户",Tag = "UserDeleteViewModel"},
                    }
                },
                new TreeNodeModel()
                {
                    Name = "设计输入",
                    Tag = "DesignInputViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/input.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "设计预览",
                    Tag = "DesignPreViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/preview.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "设计输出",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/output.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0),
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="工程图输出",Tag = "DrawingOutputViewModel"},
                        new TreeNodeModel(){Name="BOM报表",Tag = "BomReportViewModel"}
                    }
                },
                new TreeNodeModel()
                {
                    Name = "数据管理",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/data.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0),
                    Children = new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Name="零部件管理",Tag = "PartComponentMgmtViewModel"},
                        new TreeNodeModel(){Name="标准件管理",Tag = "StandardComponentMgmtViewModel"}
                    }
                },
                new TreeNodeModel()
                {
                    Name = "帮助",
                    Tag = "HelpViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/help.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                },
                new TreeNodeModel()
                {
                    Name = "关于",
                    Tag = "AboutViewModel",
                    ImagePath = AppDomain.CurrentDomain.BaseDirectory+ "Images/about.png",
                    FontSize = 18,
                    Thickness = new System.Windows.Thickness(0,1,0,0)
                }
            };
        }
    }
}
