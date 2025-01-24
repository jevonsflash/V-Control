namespace VControl.Controls.Validations;


public class MinCountOfDigitRule<T> : IValidationRule<T>
{
    private readonly int _minCount;

    public MinCountOfDigitRule(int minCount = 1)
    {
        _minCount = minCount;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is string val && !string.IsNullOrWhiteSpace(val))
        {
            return Validators.CountOfDigit(val) >= _minCount;
        }

        return false;
    }
}
