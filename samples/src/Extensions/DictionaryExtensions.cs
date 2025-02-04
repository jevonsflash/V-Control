namespace VControl.Samples.Extensions;

public static class DictionaryExtensions
{
    /// <summary>
    /// 返回Bool值, 不符合时返回DefaultValue
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static bool ValueAsBool(
        this IDictionary<string, object> dictionary,
        string key,
        bool defaultValue = false
    ) =>
        dictionary.ContainsKey(key) && dictionary[key] is bool dictValue ? dictValue : defaultValue;

    /// <summary>
    /// 返回Int值, 不符合时返回DefaultValue
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static int ValueAsInt(
        this IDictionary<string, object> dictionary,
        string key,
        int defaultValue = 0
    ) => dictionary.ContainsKey(key) && dictionary[key] is int intValue ? intValue : defaultValue;
}
