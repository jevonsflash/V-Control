using System.Globalization;
using System.Text;

namespace VControl.Samples.Converters;


public class InspectionDateConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is null || values.Length == 0)
        {
            return null;
        }

        
        if (values.All(v => string.IsNullOrEmpty(v as string)))
        {
            //触发ConvertBack方法
            return BindableProperty.UnsetValue;
        }


        string separator = parameter as string ?? " ";
        StringBuilder sb = new StringBuilder();

        if (values[0] != null && !string.IsNullOrWhiteSpace(values[0] as string)
            && values[1] != null && !string.IsNullOrWhiteSpace(values[1] as string))
        {
            var startDate = DateTime.Parse(values[0] as string);
            var endDate = DateTime.Parse(values[1] as string);

            if (startDate > DateTime.MinValue && endDate > DateTime.MinValue)
            {
                sb.Append(startDate.ToString("d"));
                if (endDate > startDate)
                {
                    sb.Append(" ~ ");
                    sb.Append(endDate.ToString("d"));
                }
            }
        }

        var serviceType = values[2] as string;
        sb.Append(" | ");
        sb.Append(serviceType?.ToUpper());
        return sb.ToString();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        string s = value as string;
        if (s == "null" || string.IsNullOrEmpty(s))
        {
            return null;
        }

        return new string[] { };


        //string separator = parameter as string ?? " ";

        //if (!targetTypes.All(t => t == typeof(object)) && !targetTypes.All(t => t == typeof(string)))
        //{
        //    return null;
        //}

        //var array = s.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).Cast<object>().ToArray();
        //for (int i = 0; i < array.Length; i++)
        //{
        //    var str = array[i] as string;
        //    if (str == null)
        //    {
        //        array[i] = null;
        //    }
        //    if (str == "UnsetValue")
        //    {
        //        array[i] = BindableProperty.UnsetValue;
        //    }
        //    if (str == "DoNothing")
        //    {
        //        array[i] = Binding.DoNothing;
        //    }
        //}
        //return array;
    }
}
