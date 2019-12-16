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
    }
}
