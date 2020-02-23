// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RangeObservableCollection.cs" company="ArcTouch LLC">
//   Copyright 2020 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the RangeObservableCollection type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

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
