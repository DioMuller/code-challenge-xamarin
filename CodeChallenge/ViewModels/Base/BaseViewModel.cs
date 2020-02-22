using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Bindable Properties
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        #endregion

        #region Virtual Methods
        public virtual Task Initialize(object parameter = null) => Task.CompletedTask;
        public virtual Task OnAppearing() => Task.CompletedTask;
        public virtual Task OnDisappearing() => Task.CompletedTask;
        #endregion

        #region INotifyPropertyChanged Methods
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
