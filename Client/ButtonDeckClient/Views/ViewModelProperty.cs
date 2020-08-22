using System.Collections.Generic;

namespace ButtonDeckClient.Views
{
    class ViewModelProperty<T> : PropertyChangedViewModel
    {
        private readonly EqualityComparer<T> _comparer;
        private T _value;

        public ViewModelProperty()
        {
            _comparer = EqualityComparer<T>.Default;
        }

        public T Value
        {
            get { return _value; }
            set
            {
                if (_comparer.Equals(_value, value))
                    return;
                _value = value;
                PropertyHasChanged();
            }
        }
    }
}
