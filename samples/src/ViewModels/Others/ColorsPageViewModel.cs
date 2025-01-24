using System.Collections.ObjectModel;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class ColorsPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<dynamic> _colorItemList1;

    [ObservableProperty]
    private ObservableCollection<dynamic> _colorItemList2;

    [ObservableProperty]
    private ObservableCollection<dynamic> _colorItemList3;

    public ColorsPageViewModel(INavigationService navService)
        : base(navService)
    {
        var res = Application.Current.Resources;
        ColorItemList1 = new ObservableCollection<dynamic>()
        {
            new
            {
                Title = "Primary",
                Color = res["Primary"],
                TextColor = res["OnPrimary"],
            },
            new
            {
                Title = "OnPrimary",
                Color = res["OnPrimary"],
                TextColor = res["Primary"],
            },
            new
            {
                Title = "PrimaryContainer",
                Color = res["PrimaryContainer"],
                TextColor = res["OnPrimaryContainer"],
            },
            new
            {
                Title = "OnPrimaryContainer",
                Color = res["OnPrimaryContainer"],
                TextColor = res["PrimaryContainer"],
            },
            new
            {
                Title = "Secondary",
                Color = res["Secondary"],
                TextColor = res["OnSecondary"],
            },
            new
            {
                Title = "OnSecondary",
                Color = res["OnSecondary"],
                TextColor = res["Secondary"],
            },
            new
            {
                Title = "SecondaryContainer",
                Color = res["SecondaryContainer"],
                TextColor = res["OnSecondaryContainer"],
            },
            new
            {
                Title = "OnSecondaryContainer",
                Color = res["OnSecondaryContainer"],
                TextColor = res["SecondaryContainer"],
            },
            new
            {
                Title = "Tertiary",
                Color = res["Tertiary"],
                TextColor = res["OnTertiary"],
            },
            new
            {
                Title = "OnTertiary",
                Color = res["OnTertiary"],
                TextColor = res["Tertiary"],
            },
            new
            {
                Title = "TertiaryContainer",
                Color = res["TertiaryContainer"],
                TextColor = res["OnTertiaryContainer"],
            },
            new
            {
                Title = "OnTertiaryContainer",
                Color = res["OnTertiaryContainer"],
                TextColor = res["TertiaryContainer"],
            },
            new
            {
                Title = "Background",
                Color = res["Background"],
                TextColor = res["OnBackground"],
            },
            new
            {
                Title = "OnBackground",
                Color = res["OnBackground"],
                TextColor = res["Background"],
            },
            new
            {
                Title = "Surface",
                Color = res["Surface"],
                TextColor = res["OnSurface"],
            },
            new
            {
                Title = "OnSurface",
                Color = res["OnSurface"],
                TextColor = res["Surface"],
            },
            new
            {
                Title = "SurfaceVariant",
                Color = res["SurfaceVariant"],
                TextColor = res["OnSurfaceVariant"],
            },
            new
            {
                Title = "OnSurfaceVariant",
                Color = res["OnSurfaceVariant"],
                TextColor = res["SurfaceVariant"],
            },
            new
            {
                Title = "Outline",
                Color = res["Outline"],
                TextColor = "Black",
            },
            new
            {
                Title = "OutlineVariant",
                Color = res["OutlineVariant"],
                TextColor = "Black",
            },
            new
            {
                Title = "Shadow",
                Color = res["Shadow"],
                TextColor = "White",
            },
        };

        ColorItemList2 = new ObservableCollection<dynamic>()
        {
            new
            {
                Title = "Error",
                Color = res["Error"],
                TextColor = res["ErrorContainer"],
            },
            new
            {
                Title = "ErrorContainer",
                Color = res["ErrorContainer"],
                TextColor = res["Error"],
            },
            new
            {
                Title = "Success",
                Color = res["Success"],
                TextColor = res["SuccessContainer"],
            },
            new
            {
                Title = "SuccessContainer",
                Color = res["SuccessContainer"],
                TextColor = res["Success"],
            },
            new
            {
                Title = "Warning",
                Color = res["Warning"],
                TextColor = res["WarningContainer"],
            },
            new
            {
                Title = "WarningContainer",
                Color = res["WarningContainer"],
                TextColor = res["Warning"],
            },
            new
            {
                Title = "DisabledText",
                Color = res["DisabledText"],
                TextColor = "White",
            },
            new
            {
                Title = "PlaceHolderText",
                Color = res["PlaceHolderText"],
                TextColor = "White",
            },
            new
            {
                Title = "DisabledBackground",
                Color = res["DisabledBackground"],
                TextColor = "White",
            },
        };

        ColorItemList3 = new ObservableCollection<dynamic>()
        {
            new
            {
                Title = "Black",
                Color = res["Black"],
                TextColor = "White",
            },
            new
            {
                Title = "White",
                Color = res["White"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray50",
                Color = res["Gray50"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray60",
                Color = res["Gray60"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray100",
                Color = res["Gray100"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray120",
                Color = res["Gray120"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray150",
                Color = res["Gray150"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray170",
                Color = res["Gray170"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray190",
                Color = res["Gray190"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray200",
                Color = res["Gray200"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray230",
                Color = res["Gray230"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray240",
                Color = res["Gray240"],
                TextColor = "Black",
            },
            new
            {
                Title = "Gray250",
                Color = res["Gray250"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray270",
                Color = res["Gray270"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray300",
                Color = res["Gray300"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray360",
                Color = res["Gray360"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray380",
                Color = res["Gray380"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray400",
                Color = res["Gray400"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray500",
                Color = res["Gray500"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray550",
                Color = res["Gray550"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray600",
                Color = res["Gray600"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray900",
                Color = res["Gray900"],
                TextColor = "White",
            },
            new
            {
                Title = "Gray950",
                Color = res["Gray950"],
                TextColor = "White",
            },
        };
    }
}
