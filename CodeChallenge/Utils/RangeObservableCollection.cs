using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CodeChallenge.Utils
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        #region Constructors
        public RangeObservableCollection() : base() { }
        public RangeObservableCollection(IEnumerable<T> collection) : base(collection) { }
        public RangeObservableCollection(List<T> list) : base(list) { }
        #endregion

        #region Public Methods
        public void AddRange(IEnumerable<T> range)
        {
            foreach( var item in range )
            {
                Items.Add(item);
            }

            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        #endregion
    }
}
