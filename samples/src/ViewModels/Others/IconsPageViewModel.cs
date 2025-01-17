using System.Collections.ObjectModel;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class IconsPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<dynamic> _iconItemList;
    public IconsPageViewModel(
        INavigationService navService)

        : base(navService)
    {

        var res = Application.Current.Resources;
        IconItemList = new ObservableCollection<dynamic>(){
            new { Title= "house"  , Icon="\uF015", TextColor="Red",  FontFamily="FontAwesome-Solid"},
            new { Title= "magnifying-glass"  , Icon="\uF002", TextColor="green",  FontFamily="FontAwesome-Solid" },
            new { Title= "user"  , Icon="\uF007", TextColor="orange" ,  FontFamily="FontAwesome-Solid"},
            new { Title= "facebook"  , Icon="\uF09a", TextColor="blue" ,  FontFamily="FontAwesome-Brands"},
            new { Title= "check"  , Icon="\uF00c", TextColor="green" ,  FontFamily="FontAwesome-Solid"},
            new { Title= "download"  , Icon="\uF019", TextColor="Red",  FontFamily="FontAwesome-Solid" },
        };

    }

}
