using System;
using System.ComponentModel;

namespace ButtonDeckClient.Views
{
    class ReadOnlyViewModelProperty<T> : PropertyChangedViewModel
    {
        private readonly Func<T> _createValue;
        private readonly INotifyPropertyChanged _source;
        private T _value;

        public ReadOnlyViewModelProperty(INotifyPropertyChanged source, Func<T> createValue)
        {
            _createValue = createValue;
            _source = source;
            _source.PropertyChanged += _source_PropertyChanged;
            UpdateValue();
        }

        private void _source_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            Value = _createValue();
        }

        public T Value
        {
            get { return _value; }
            private set
            {
                _value = value;
                PropertyHasChanged();
            }
        }
    }
}
