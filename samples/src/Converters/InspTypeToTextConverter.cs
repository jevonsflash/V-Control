using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace VControl.Samples.Converters;

public class InspTypeToTextConverter : BaseConverterOneWay<int, string>
{
    public override string DefaultConvertReturnValue { get; set; }

    public override string ConvertFrom(int value, CultureInfo cultureInfo)
    {
            return value == 2 ? "Re-inspection" : "First inspection";
        
    }
}
