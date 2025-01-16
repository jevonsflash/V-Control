using System.Globalization;

namespace VControl.Samples.Converters
{
    public class DateTimeToDateOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateOnly)
            {
                DateOnly date = (DateOnly)value;
                return date.ToDateTime(TimeOnly.MinValue);
            }
            return DateTime.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                return DateOnly.FromDateTime(date);
            }
            return DateOnly.MinValue;
        }
    }
}
