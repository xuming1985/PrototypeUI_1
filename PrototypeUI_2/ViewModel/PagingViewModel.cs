using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeUI_2.ViewModel
{
    public class PagingViewModel : ViewModelBase
    {
        private int _pageInput;
        private int _page = 0;
        private int _pageCount = 12;
        private int _total;
        private int _totalPage;

        public int PageInput
        {
            get { return _pageInput; }
            set
            {
                if (_pageInput != value)
                {
                    _pageInput = value;
                    RaisePropertyChanged("PageInput");
                }
            }
        }

        public int TotalPage
        {
            get { return _totalPage; }
            set
            {
                if (_totalPage != value)
                {
                    _totalPage = value;
                    RaisePropertyChanged("TotalPage");
                }
            }
        }


        public void Init(int total)
        {
            _page = 0;
            _total = total;
            _totalPage = Convert.ToInt32(Math.Ceiling(total*1.0 / _pageCount));
        }
    }
}
