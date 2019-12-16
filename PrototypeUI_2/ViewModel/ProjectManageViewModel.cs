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
        private int _page = 0;
        private int _count = 15;
        private PagingViewModel _paging;

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
        public List<string> EntrustingParts { get; set; }
        public ObservableCollection<ProjectModel> Projects { get; set; }

        public ProjectManageViewModel()
        {
            Projects = new ObservableCollection<ProjectModel>();
            PagingVM = new PagingViewModel();
            EntrustingParts = MockService.GetEntrustingParts();

            var result = MockService.GetProjects(EntrustingPart, CreateTimeStart, NameKey, _page, _count) ;
            PagingVM.Init(result.Total);
            foreach (var item in result.Data)
            {
                Projects.Add(item);
            }
        }
    }
}
