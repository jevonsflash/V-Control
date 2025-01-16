using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace VControl.Samples.Converters
{
    public class DoubleCalculationConverter : BaseConverterOneWay<double, double>
    {
        public override double DefaultConvertReturnValue { get; set; } = 0;

        public override double ConvertFrom(double value, CultureInfo culture)
        {
            return value - 50;
        }
    }
}
