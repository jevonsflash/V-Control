using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace VControl.Samples.Converters;

public class CountToVisibleConverter : BaseConverterOneWay<int, bool>
{
    public override bool DefaultConvertReturnValue { get; set; } = false;

    public override bool ConvertFrom(int value, CultureInfo culture)
    {
        return value > 0;
    }
}
