using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace PrototypeUI_2.ViewModel
{
    public class PagingViewModel : ViewModelBase
    {
        private int _page = 0;
        private int _pageCount = 12;
        private int _total;
        private int _totalPage;

        private string _b1Content = "1";
        private string _b2Content = "2";
        private string _b3Content = "3";

        private Visibility _b2Visibility = Visibility.Collapsed;
        private Visibility _b3Visibility = Visibility.Collapsed;

        //当前页
        public int Page
        {
            get { return _page; }
            set
            {
                if (_page != value)
                {
                    _page = value;
                    if (value > TotalPage) _page = TotalPage;
                    if (value < 1) _page = 1;
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

        public string B1Content
        {
            get { return _b1Content; }
            set
            {
                if (_b1Content != value)
                {
                    _b1Content = value;
                    RaisePropertyChanged("B1Content");
                }
            }
        }

        public string B2Content
        {
            get { return _b2Content; }
            set
            {
                if (_b2Content != value)
                {
                    _b2Content = value;
                    RaisePropertyChanged("B2Content");
                }
            }
        }

        public string B3Content
        {
            get { return _b3Content; }
            set
            {
                if (_b3Content != value)
                {
                    _b3Content = value;
                    RaisePropertyChanged("B3Content");
                }
            }
        }

        public Visibility B2Visibility
        {
            get { return _b2Visibility; }
            set
            {
                if (_b2Visibility != value)
                {
                    _b2Visibility = value;
                    RaisePropertyChanged("B2Visibility");
                }
            }
        }

        public Visibility B3Visibility
        {
            get { return _b3Visibility; }
            set
            {
                if (_b3Visibility != value)
                {
                    _b3Visibility = value;
                    RaisePropertyChanged("B3Visibility");
                }
            }
        }

        public RelayCommand PrePageCommand { get; set; }
        public RelayCommand NextPageCommand { get; set; }

        public RelayCommand<string> PageCommand { get; set; }


        public Action<int> PageChangedAction;

        public PagingViewModel()
        {
            PrePageCommand = new RelayCommand(PrePage);
            NextPageCommand = new RelayCommand(NextPage);
            PageCommand = new RelayCommand<string>(PageNavigate);
        }

        public void Init(int total)
        {
            _total = total;
            _totalPage = Convert.ToInt32(Math.Ceiling(total*1.0 / _pageCount));
            Page = 1;

            if (_totalPage >= 3)
            {
                B2Visibility = Visibility.Visible;
                B3Visibility = Visibility.Visible;
            }
            else if(_totalPage == 2)
            {
                B2Visibility = Visibility.Visible;
                B3Visibility = Visibility.Collapsed;
            }
        }
    
    
        private void PrePage()
        {
            if (Page > 1)
            {
                Page--;
            }
            PageChangedAction?.Invoke(Page);
        }

        private void NextPage()
        {
            if (Page < TotalPage)
            {
                Page++;
            }
            PageChangedAction?.Invoke(Page);
        }

        private void PageNavigate(string page)
        {
            int curPage = Page;
            if( int.TryParse(page, out curPage))
            {
                Page = curPage;
            }

            PageChangedAction?.Invoke(Page);
        }
    }
}
