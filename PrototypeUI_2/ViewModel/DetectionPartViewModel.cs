using PrototypeUI_2.Core;
using PrototypeUI_2.Model;
using System.Collections.ObjectModel;

namespace PrototypeUI_2.ViewModel
{
    public class DetectionPartViewModel : PopViewModel
    {
        private PagingViewModel _paging;
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
        public ObservableCollection<DetectionPartModel> Models { get; set; }

        public DetectionPartViewModel()
        {
            Models = new ObservableCollection<DetectionPartModel>();
            PagingVM = new PagingViewModel() { PageCount = 10 };

            var result = MockService.GetEntrustingParts(PagingVM.Page, PagingVM.PageCount);
            PagingVM.Init(result.Total);
            foreach (var item in result.Data)
            {
                Models.Add(item);
            }
        }
    }
}
