namespace VControl.Controls.Validations;

public class LessThanRule<T> : IValidationRule<T>
{
    private readonly double _upperLimitValue;
    private readonly bool _isEqualValid;

    public LessThanRule(double value, bool isEqualValid = false)
    {
        this._upperLimitValue = value;
        this._isEqualValid = isEqualValid;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) =>
      _isEqualValid ? Convert.ToDouble(value) <= _upperLimitValue : Convert.ToDouble(value) < _upperLimitValue;
}
