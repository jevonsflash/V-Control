using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace VControl.Controls
{
    public abstract class ItemWrapperBase : INotifyPropertyChanged
    {
        private object _value;

        private string _displayPropertyName;

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayValue)));
            }
        }

        public object DisplayValue => GetDisplayTitle(this.DisplayPropertyName);

        public string DisplayPropertyName
        {
            get => _displayPropertyName;
            set => SetProperty(ref _displayPropertyName, value);
        }

        protected virtual object GetDisplayTitle(string propertyName)
        {
            if (Value == default)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                return Value.ToString();
            }
            else
            {
                Type type = Value.GetType();

                var property = type.GetProperty(propertyName);

                if (property == null)
                {
                    throw new ArgumentException(
                        $"Property '{propertyName}' not found on {type.FullName}"
                    );
                }
                var title = property.GetValue(Value);
                return title;
            }
        }

        protected virtual bool SetProperty<T>(
            [NotNullIfNotNull(nameof(newValue))] ref T field,
            T newValue,
            [CallerMemberName] string? propertyName = null
        )
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
