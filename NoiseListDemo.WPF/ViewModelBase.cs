using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoiseListDemo.WPF
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase
    {
        private T _dataObject { get; set; }

        protected T DataObject
        {
            get
            {
                return _dataObject;
            }

            set
            {
                _dataObject = value;
            }
        }

        protected ViewModelBase(T t)
        {
            _dataObject = t;
        }
    }
}