using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace VControl.Samples.Converters;

public class CountToInvisibleConverter : BaseConverterOneWay<int, bool>
{
    public override bool DefaultConvertReturnValue { get; set; } = false;

    public override bool ConvertFrom(int value, CultureInfo culture)
    {
        return value <= 0;
    }
}
