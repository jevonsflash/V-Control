using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace VControl.Samples.Converters
{
    public class ServiceTypeToLowerTextConverter : BaseConverterOneWay<bool, string>
	{
		public override string DefaultConvertReturnValue { get; set; }

		public override string ConvertFrom(bool isAudit, CultureInfo cultureInfo)
		{
			if (isAudit)
			{
				return "audit";
			}
			else
			{
				return "inspection";
			}
		}
	}
}
