﻿namespace VControl.Controls.Validations;

/// <summary>
/// 是否用户名或邮箱
/// </summary>
/// <typeparam name="T"></typeparam>
public class MinCountOfUpperLetterRule<T> : IValidationRule<T>
{
    private readonly int _minCount;

    public MinCountOfUpperLetterRule(int minCount = 1)
    {
        _minCount = minCount;
    }

    public string ValidationMessage { get; set; }

    public bool Check(T value)
    {
        if (value is string val && !string.IsNullOrWhiteSpace(val))
        {
            return Validators.CountOfUpperLetter(val) >= _minCount;
        }

        return false;
    }
}
