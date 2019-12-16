﻿using PrototypeUI_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeUI_2.Core
{
    public static class MockService
    {
        private static List<ProjectModel> _projects;
        private static List<ProjectStatisticsModel> _projectStatistics;
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

        public static PagedSearchResult<ProjectModel> GetProjectStatistics()
        {
            return _projectStatistics;
        }

        public static List<string> GetEntrustingParts()
        {
            return _entrustingParts;
        }
    }
}
