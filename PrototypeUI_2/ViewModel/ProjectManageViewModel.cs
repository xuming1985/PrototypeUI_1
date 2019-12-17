using GalaSoft.MvvmLight;
using PrototypeUI_2.Core;
using PrototypeUI_2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeUI_2.ViewModel
{
    public class ProjectManageViewModel: ViewModelBase
    {
        private string _entrustingPart;
        private string _nameKey;
        private DateTime? _createTimeStart;
        private PagingViewModel _paging;
        private PagingViewModel _pagingStatistics;

        public string EntrustingPart
        {
            get { return _entrustingPart; }
            set
            {
                if (_entrustingPart != value)
                {
                    _entrustingPart = value;
                    RaisePropertyChanged("EntrustingPart");
                }
            }
        }
        public string NameKey
        {
            get { return _nameKey; }
            set
            {
                if (_nameKey != value)
                {
                    _nameKey = value;
                    RaisePropertyChanged("NameKey");
                }
            }
        }
        public DateTime? CreateTimeStart
        {
            get { return _createTimeStart; }
            set
            {
                if (_createTimeStart != value)
                {
                    _createTimeStart = value;
                    RaisePropertyChanged("CreateTimeStart");
                }
            }
        }
        public PagingViewModel PagingVM
        {
            get { return _paging; }
            set
            {
                if (_paging != value)
                {
                    _paging = value;
                    RaisePropertyChanged("PagingVM");
                }
            }
        }
        public PagingViewModel PagingStatisticsVM
        {
            get { return _pagingStatistics; }
            set
            {
                if (_pagingStatistics != value)
                {
                    _pagingStatistics = value;
                    RaisePropertyChanged("PagingStatisticsVM");
                }
            }
        }
        public List<string> EntrustingParts { get; set; }
        public ObservableCollection<ProjectModel> Projects { get; set; }
        public ObservableCollection<ProjectStatisticsModel> Statistics { get; set; }
        
        public ProjectManageViewModel()
        {
            Projects = new ObservableCollection<ProjectModel>();
            Statistics = new ObservableCollection<ProjectStatisticsModel>();
            PagingVM = new PagingViewModel();
            PagingStatisticsVM = new PagingViewModel();
            EntrustingParts = MockService.GetEntrustingParts();

            var result = MockService.GetProjects(EntrustingPart, CreateTimeStart, NameKey, PagingVM.Page, PagingVM.PageCount) ;
            PagingVM.Init(result.Total);
            foreach (var item in result.Data)
            {
                Projects.Add(item);
            }

            var resultStatistics = MockService.GetProjectStatistics(PagingStatisticsVM.Page, PagingStatisticsVM.PageCount);
            PagingStatisticsVM.Init(resultStatistics.Total);
            foreach (var item in resultStatistics.Data)
            {
                Statistics.Add(item);
            }
        }
    }
}
