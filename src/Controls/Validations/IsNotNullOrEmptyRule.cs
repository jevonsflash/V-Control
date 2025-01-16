namespace VControl.Controls.Validations;

public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is string str)
            return !string.IsNullOrWhiteSpace(str);

        else if (!Equals(value, default(T)))
            return true;

        return false;
    }
}
