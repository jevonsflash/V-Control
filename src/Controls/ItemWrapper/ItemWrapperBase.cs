using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VControl.Controls
{

    public abstract class ItemWrapperBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

    

        private object _value;

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



        private string _displayPropertyName;

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
                    throw new ArgumentException($"Property '{propertyName}' not found on {type.FullName}");
                }
                var title = property.GetValue(Value);
                return title;
            }
        }

        protected virtual bool SetProperty<T>([NotNullIfNotNull(nameof(newValue))] ref T field, T newValue, [CallerMemberName] string? propertyName = null)
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
