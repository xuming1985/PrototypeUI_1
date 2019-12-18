using PrototypeUI_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrototypeUI_2.Core
{
    public static class MockService
    {
        private static List<ProjectModel> _projects;
        private static List<ProjectStatisticsModel> _projectStatistics;
        private static List<DetectionPartModel> _detectionParts;
        private static List<TreeItemModel> _departments;
        private static List<UserModel> _users;
        private static List<string> _names;
        private static List<string> _status;
        private static List<string> _entrustingParts;

        static MockService()
        {
            _names = new List<string>() { "张三", "李一一", "王五", "赵四", "孙二雷", "赵大年", "钱多多", "周大福", "吴甜甜", "郑和", "韩梅梅", "刘一手", "郭天南", "马娇娇" };
            _status = new List<string>() { "进行中", "已结束" };
            _entrustingParts = new List<string>() { "中国-一建", "中国-二建", "中国-三建", "中国-四建", "中国-六五建", "中国-六建" };
            InitProjectModel();
            InitProjectStatisticsModel();
            InitDetectionPartModel();
            InitDepartments();
            InitUserModels();
        }

        private static void InitProjectModel()
        {
            Random r = new Random();
            _projects = new List<ProjectModel>();
            for (int i = 1; i <= 49; i++)
            {
                var model = new ProjectModel();
                model.SerialNo = i.ToString();
                model.Name = "大连管道监测项目";
                model.Address = "大连高新园区-黄浦路";
                model.EntrustingPart = "中国-六建";
                model.DetectionPart = "北京检测技术有限公司";
                model.Approver = _names[r.Next(0, _names.Count)];
                model.Verifier = _names[r.Next(0, _names.Count)];
                model.Auditor = _names[r.Next(0, _names.Count)];
                model.Checker = _names[r.Next(0, _names.Count)];
                model.Author = _names[r.Next(0, _names.Count)];
                model.Administrator = _names[r.Next(0, _names.Count)];
                model.InnerOperator = $"{_names[r.Next(0, _names.Count)]},{_names[r.Next(0, _names.Count)]},{_names[r.Next(0, _names.Count)]}";
                model.OutterOperator = $"{_names[r.Next(0, _names.Count)]},{_names[r.Next(0, _names.Count)]},{_names[r.Next(0, _names.Count)]}";
                model.CreateTime = DateTime.Now.AddDays(1 - i);
                _projects.Add(model);
            }
        }

        private static void InitProjectStatisticsModel()
        {
            Random r = new Random();
            _projectStatistics = new List<ProjectStatisticsModel>();
            for (int i = 1; i <= 49; i++)
            {
                var model = new ProjectStatisticsModel();
                model.SerialNo = i.ToString();
                model.Name = "大连管道监测项目";
                model.Road = r.Next(20, 30);
                model.Pipe = r.Next(20, 30);
                model.CheckMile = r.Next(10, 20) / 10.0;
                model.ReadedMile = r.Next(10, 20) / 10.0;
                model.CheckedMile = r.Next(10, 20) / 10.0;
                model.BeginDate = DateTime.Now.AddDays(1-i);
                model.PlanCompleteDate = model.BeginDate.AddMonths(6);
                model.EvaluationStandard = "***缺陷评估报告";
                model.Status = _status[r.Next(0, 1)];
                model.Progress = r.Next(1, 10) * 10;
                _projectStatistics.Add(model);
            }
        }

        private static void InitDetectionPartModel()
        {
            Random r = new Random();
            _detectionParts = new List<DetectionPartModel>();
            for (int i = 1; i <= 49; i++)
            {
                var model = new DetectionPartModel();
                model.Index = i;
                model.Name = "大连*******有限公司";
                model.Address = "大连高新园区-黄浦路110号";
                model.Contacts = _names[r.Next(0, _names.Count)];
                model.ContactPhone = "0411-88886666";
                model.Email = "123456@qq.com";
                model.Logo = "";
                _detectionParts.Add(model);
            }
        }

        private static void InitDepartments()
        {
            _departments = new List<TreeItemModel>();
            _departments.Add(new TreeItemModel()
            {
                Id = 1,
                Name = "开发部",
                OutterLine = new System.Windows.Thickness(0, 0, 0, 1),
                Padding = new System.Windows.Thickness(30, 10, 0, 10),
                Children = new List<TreeItemModel>()
                {
                    new TreeItemModel(){ Id = 11, Name = "开发一部", Padding = new System.Windows.Thickness(60, 00, 0, 0)},
                    new TreeItemModel(){ Id = 12, Name = "开发二部", Padding = new System.Windows.Thickness(60, 00, 0, 0)},
                    new TreeItemModel(){ Id = 13, Name = "开发三部", Padding = new System.Windows.Thickness(60, 00, 0, 0)}
                }
            }); ;
            _departments.Add(new TreeItemModel()
            {
                Id = 2,
                Name = "销售部",
                OutterLine = new System.Windows.Thickness(0, 0, 0, 1),
                Padding = new System.Windows.Thickness(30, 10, 0, 10),
                Children = new List<TreeItemModel>()
                {
                    new TreeItemModel(){ Id = 21, Name = "销售一部", Padding = new System.Windows.Thickness(60, 00, 0, 0)},
                    new TreeItemModel(){ Id = 22, Name = "销售二部", Padding = new System.Windows.Thickness(60, 00, 0, 0)},
                    new TreeItemModel(){ Id = 23, Name = "销售三部", Padding = new System.Windows.Thickness(60, 00, 0, 0)}
                }
            });
            _departments.Add(new TreeItemModel()
            {
                Id = 3,
                Name = "财务部部",
                OutterLine = new System.Windows.Thickness(0, 0, 0, 1),
                Padding = new System.Windows.Thickness(30, 10, 0, 10),
            });
        }

        private static void InitUserModels()
        {
            Random r = new Random();
            _users = new List<UserModel>();
            for (int i = 1; i <= 49; i++)
            {
                var model = new UserModel();
                model.Index = i;
                model.Name = $"dl{i.ToString("000")}";
                model.RealName = _names[r.Next(0, _names.Count)];
                model.Phone = "0411-88886666";
                model.RegisterTime = DateTime.Now.AddDays(-r.Next(1, 300)).ToString("yyyy-MM-dd");
                model.Status = "有效";
                model.Department = _departments[r.Next(0, _departments.Count)].Name;
                model.Role = "操作员";
                _users.Add(model);
            }
        }


        public static PagedSearchResult<ProjectModel> GetProjects(string entrustingPart, DateTime? dateTimeStart, string nameKey, int page, int count)
        {
            var projects = _projects.Where(o => !string.IsNullOrWhiteSpace(o.Name));
            if (!string.IsNullOrWhiteSpace(entrustingPart))
                projects = projects.Where(o => o.EntrustingPart == entrustingPart);

            if (dateTimeStart.HasValue)
                projects = projects.Where(o => o.CreateTime >= dateTimeStart.Value);

            if (!string.IsNullOrWhiteSpace(nameKey))
                projects = projects.Where(o => o.Name.Contains(nameKey));

            var result = new PagedSearchResult<ProjectModel>();
            result.Total = projects.Count();
            result.Data = projects.Skip((page - 1) * count).Take(count).ToList();
            return result;
        }

        public static PagedSearchResult<ProjectStatisticsModel> GetProjectStatistics(int page, int count)
        {
            var result = new PagedSearchResult<ProjectStatisticsModel>();
            result.Total = _projectStatistics.Count();
            result.Data = _projectStatistics.Skip((page - 1) * count).Take(count).ToList();
            return result;
        }

        public static PagedSearchResult<DetectionPartModel> GetEntrustingParts(int page, int count)
        {
            var result = new PagedSearchResult<DetectionPartModel>();
            result.Total = _detectionParts.Count();
            result.Data = _detectionParts.Skip((page - 1) * count).Take(count).ToList();
            return result;
        }

        public static PagedSearchResult<UserModel> GetUsers(int page, int count)
        {
            var result = new PagedSearchResult<UserModel>();
            result.Total = _users.Count();
            result.Data = _users.Skip((page - 1) * count).Take(count).ToList();
            return result;
        }

        public static List<string> GetEntrustingParts()
        {
            return _entrustingParts;
        }
        public static List<TreeItemModel> GetDepartments()
        {
            return _departments;
        }
    }
}
