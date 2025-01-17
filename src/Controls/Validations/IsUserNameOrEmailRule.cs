namespace VControl.Controls.Validations;

/// <summary>
/// 是否用户名或邮箱
/// </summary>
/// <typeparam name="T"></typeparam>
public class IsUserNameOrEmailRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is string val && !string.IsNullOrWhiteSpace(val))
        {
            return Validators.IsAccount(val) || Validators.IsEmail(val);
        }

        return false;
    }
}
