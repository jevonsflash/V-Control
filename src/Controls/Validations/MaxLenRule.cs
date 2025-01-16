namespace VControl.Controls.Validations;

public class MaxLenRule<T> : IValidationRule<T>
{
    private readonly int _maxLen;
    public MaxLenRule(int maxLength)
    {
        _maxLen = maxLength;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) =>
        value is string str &&
        !string.IsNullOrWhiteSpace(str)
        && str.Length <= _maxLen;
}

