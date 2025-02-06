namespace VControl.Controls.Validations;

public class MoreThanRule<T> : IValidationRule<T>
{
    private readonly double _underLimitValue;
    private readonly bool _isEqualValid;

    public MoreThanRule(double value, bool isEqualValid = false)
    {
        this._underLimitValue = value;
        this._isEqualValid = isEqualValid;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value) =>
       _isEqualValid ? Convert.ToDouble(value) >= _underLimitValue : Convert.ToDouble(value) > _underLimitValue;
}
