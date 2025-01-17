using System.Globalization;

namespace VControl.Converters;
public class FirstValidationErrorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IEnumerable<string> v)
        {
            return v?.FirstOrDefault();
        }
        return string.Empty;
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
