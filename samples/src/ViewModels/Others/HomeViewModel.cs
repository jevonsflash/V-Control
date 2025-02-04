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

    public HomeViewModel(INavigationService navService)
        : base(navService)
    {
        BasicViewItemList = new ObservableCollection<HomeViewItem>()
        {
            new HomeViewItem()
            {
                Title = "内置样式",
                Url = "StyleSamplesPage",
                Info = "",
                Icon = "vbutton",
            },
            new HomeViewItem()
            {
                Title = "颜色系统",
                Url = "ColorsPage",
                Info = "",
                Icon = "vbutton",
            },
            new HomeViewItem()
            {
                Title = "图标",
                Url = "IconsPage",
                Info = "",
                Icon = "vbutton",
            },
        };

        ControlViewItemList = new ObservableCollection<HomeViewItem>()
        {
            new HomeViewItem()
            {
                Title = "VButton",
                Url = "VButtonView",
                Info = "",
                Icon = "vbutton",
            },
            new HomeViewItem()
            {
                Title = "VCard",
                Url = "VCardView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VRadioButtonGroup",
                Url = "VRadioButtonGroupView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VRadioButton",
                Url = "VRadioButtonView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VTouchContentView",
                Url = "VTouchContentViewView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VTopAppBar",
                Url = "VTopAppBarView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VPlaceholderView",
                Url = "VPlaceholderViewView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VCheckableCollection",
                Url = "VCheckableCollectionView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VCheckBox",
                Url = "VCheckBoxView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VEntry",
                Url = "VEntryView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VValidatingEntry",
                Url = "VValidatingEntryView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VEditor",
                Url = "VEditorView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VMenuCell",
                Url = "VMenuCellView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VDatePicker",
                Url = "VDatePickerView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VExpander",
                Url = "VExpanderView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VNumberEntry",
                Url = "VNumberEntryView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VSearchBar",
                Url = "VSearchBarView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VTimeLine",
                Url = "VTimeLineView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VTagPicker",
                Url = "VTagPickerView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VRichTextEditor",
                Url = "VRichTextEditorView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VCheckBoxButton",
                Url = "VCheckBoxButtonView",
                Info = "",
                Icon = "vcard",
            },
            new HomeViewItem()
            {
                Title = "VCollectionView",
                Url = "VCollectionView",
                Info = "",
                Icon = "vcard",
            },new HomeViewItem()
            {
                Title = "VDateNativePicker",
                Url = "VDateNativePickerView",
                Info = "",
                Icon = "vcard",
            },
        };
    }
}
