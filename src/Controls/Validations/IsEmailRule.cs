using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VControl.Controls.Validations;

/// <summary>
/// 是否邮箱
/// </summary>
/// <typeparam name="T"></typeparam>
public class IsEmailRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is string email && !string.IsNullOrWhiteSpace(email))
        {
            return Validators.IsEmail(email);
        }

        return false;
    }
}
