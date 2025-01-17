using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace VControl.Controls.Validations;

public class ValidatableObject<T> : INotifyPropertyChanged, IValidatableObject
{
    private IEnumerable<string> _errors;
    private bool _isValid;
    private T _value;

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<IValidationRule<T>> Validations { get; } = new();

    public IEnumerable<string> Errors
    {
        get => _errors;
        set => SetProperty(ref _errors, value);
    }

    public bool IsValid
    {
        get => _isValid;
        set => SetProperty(ref _isValid, value);
    }

    public T Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    public ValidatableObject()
    {
        _isValid = true;
        _errors = Enumerable.Empty<string>();
    }

    protected bool SetProperty<T>(
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

    public bool Validate()
    {
        Errors =
            Validations?.Where(v => !v.Check(Value))?.Select(v => v.ValidationMessage)?.ToArray()
            ?? Enumerable.Empty<string>();

        IsValid = !Errors.Any();

        return IsValid;
    }
}
