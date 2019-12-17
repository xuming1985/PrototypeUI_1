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
        private int _page = 0;
        private int _pageCount = 12;
        private int _total;
        private int _totalPage;

        //当前页
        public int Page
        {
            get { return _page; }
            set
            {
                if (_page != value)
                {
                    _page = value;
                    RaisePropertyChanged("Page");
                }
            }
        }

        //每页显示数量
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                if (_pageCount != value)
                {
                    _pageCount = value;
                    RaisePropertyChanged("PageCount");
                }
            }
        }

        //共多少页
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
