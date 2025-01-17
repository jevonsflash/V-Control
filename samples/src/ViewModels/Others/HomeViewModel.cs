using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<HomeViewItem> _basicViewItemList;

    [ObservableProperty]
    private ObservableCollection<HomeViewItem> _controlViewItemList;

    public HomeViewModel(
        INavigationService navService)

        : base(navService)
    {
        BasicViewItemList = new ObservableCollection<HomeViewItem>()
        {
            new HomeViewItem(){ Title="内置样式",  Url="StyleSamplesPage", Info="", Icon="vbutton"},
            new HomeViewItem(){ Title="颜色系统",  Url="ColorsPage", Info="", Icon="vbutton"},
            new HomeViewItem(){ Title="图标",  Url="IconsPage", Info="", Icon="vbutton"},

        };

        ControlViewItemList = new ObservableCollection<HomeViewItem>()
        {
            new HomeViewItem(){ Title="VButton",  Url="VButtonView", Info="", Icon="vbutton"},
            new HomeViewItem(){ Title="VCard",  Url="VCardView", Info="", Icon="vcard"},
            new HomeViewItem(){ Title="VRadioButton",  Url="VRadioButtonView", Info="", Icon="vcard"},
            new HomeViewItem(){ Title="VTouchContentView",  Url="VTouchContentViewView", Info="", Icon="vcard"},
            new HomeViewItem(){ Title="VTopAppBar",  Url="VTopAppBarView", Info="", Icon="vcard"},
            new HomeViewItem(){ Title="VPlaceholderView",  Url="VPlaceholderViewView", Info="", Icon="vcard"}

        };
    }

}
