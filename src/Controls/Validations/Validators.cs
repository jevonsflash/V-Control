using System.Text.RegularExpressions;

namespace VControl.Controls.Validations;

public class Validators
{
    /// <summary>
    /// 是否邮箱
    /// 从order复制
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        if (email.Length > 100) return false;

        if (email.Contains("..") || email.Contains("__") || email.Contains("_-") || email.Contains("-_"))
            return false;

        var arr = email.Split(new[] { '.', '@' });
        foreach (var n in arr)
        {
            if (n.StartsWith("_") || n.StartsWith("-")
                || n.EndsWith("_") || n.EndsWith("-")
                )
                return false;
        }

        Regex regEmail = new Regex("^[0-9a-zA-Z]+[_\\.0-9a-zA-Z-]+@([0-9a-zA-Z][0-9a-zA-Z-]+\\.){1,4}[a-zA-Z]{2,6}$");

        return regEmail.Match(email).Success;
    }

    /// <summary>
    /// 是否登录账户
    /// 从order复制
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static bool IsAccount(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return false;

        if (val.Contains("--") || val.Contains("..") || val.Contains("__"))
            return false;

        Regex reg = new Regex("^[0-9a-zA-Z]{1}[0-9a-zA-Z-_.]{2,20}[0-9a-zA-Z]{1}$");
        Match m = reg.Match(val);
        return m.Success;
    }



    /// <summary>
    /// 返回包括数字的数量 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int CountOfDigit(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return 0;

        Regex reg = new Regex(@"\d");
        return reg.Matches(val).Count();
    }


    /// <summary>
    /// 返回包括大写字母的数量 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int CountOfUpperLetter(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return 0;

        Regex reg = new Regex(@"[A-Z]");
        return reg.Matches(val).Count();
    }
}
