namespace VControl.Controls.Validations;

public class MinLenRule<T> : IValidationRule<T>
{
    private readonly int _minLen;

    public MinLenRule(int minLength)
    {
        _minLen = minLength;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) =>
        value is string str && !string.IsNullOrWhiteSpace(str) && str.Length >= _minLen;
}
