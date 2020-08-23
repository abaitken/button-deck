using System;
using System.Collections.Generic;

namespace ButtonDeckClient.Views
{
    class ViewModelProperty<T> : PropertyChangedViewModel
    {
        private readonly EqualityComparer<T> _comparer;
        private readonly Action _onChanged;
        private T _value;
        
        public event EventHandler OnChanged;

        public ViewModelProperty()
        {
            _comparer = EqualityComparer<T>.Default;
        }

        public ViewModelProperty(Action onChanged)
            : this()
        {
            _onChanged = onChanged;
        }

        public T Value
        {
            get { return _value; }
            set
            {
                if (_comparer.Equals(_value, value))
                    return;
                _value = value;
                OnChange();
            }
        }

        private void OnChange()
        {
            OnChanged?.Invoke(this, EventArgs.Empty);
            _onChanged?.Invoke();
            PropertyHasChanged(nameof(Value));
        }
    }
}
