using System.Globalization;

namespace VControl.Samples.Converters
{
    public class Bool2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (string.IsNullOrEmpty((string)parameter))
                {
                    parameter = "是|否";
                }
                var str1 = (parameter as string).Split('|')[0];
                var str2 = (parameter as string).Split('|')[1];

                if (value is bool)
                {
                    return (bool)value ? str1 : str2;
                }
                else
                {
                    string status = value.ToString().ToUpper();
                    if (status.Equals("TRUE"))
                    {
                        return str1;
                    }
                    else
                    {
                        return str2;
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
