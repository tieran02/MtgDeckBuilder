using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MTG_DeckBuilder_Model.Annotations;

namespace MTG_DeckBuilder_Model
{
    public abstract class PagedResultBase : INotifyPropertyChanged
    {
        private int _currentPage;
        private int _pageCount;
        private int _pageSize;
        private int _rowCount;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (value == _currentPage) return;
                _currentPage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FirstRowOnPage));
                OnPropertyChanged(nameof(LastRowOnPage));
            }
        }

        public int PageCount
        {
            get => _pageCount;
            set
            {
                if (value == _pageCount) return;
                _pageCount = value;
                OnPropertyChanged();
            }
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value == _pageSize) return;
                _pageSize = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FirstRowOnPage));
                OnPropertyChanged(nameof(LastRowOnPage));
            }
        }

        public int RowCount
        {
            get => _rowCount;
            set
            {
                if (value == _rowCount) return;
                _rowCount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LastRowOnPage));
            }
        }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        private IList<T> _results;

        public IList<T> Results
        {
            get => _results;
            set
            {
                if (Equals(value, _results)) return;
                _results = value;
                OnPropertyChanged();
            }
        }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
