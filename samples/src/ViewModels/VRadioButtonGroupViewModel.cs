using System.Collections.ObjectModel;
using VControl.Controls;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VRadioButtonGroupViewModel : ViewModelBase
{
    public VRadioButtonGroupViewModel(INavigationService navService)
        : base(navService)
    {
        InspTypeList = new ObservableCollection<IRadioButtonModel>()
        {
            new RadioButtonModel()
            {
                Id = "1",
                Value = "Booking",
                Icon = "\uF0eb",
            },
            new RadioButtonModel()
            {
                Id = "2",
                Value = "Reports",
                Icon = "\uE4f0",
            },
            new RadioButtonModel()
            {
                Id = "3",
                Value = "Documents",
                Icon = "\uF15b",
            },
        };
        this.InspType = InspTypeList.FirstOrDefault().Id;

        InspTypeList2 = new ObservableCollection<IRadioButtonModel>()
        {
            new RadioButtonModel() { Id = "1", Value = "Booking" },
            new RadioButtonModel() { Id = "2", Value = "Reports" },
            new RadioButtonModel() { Id = "3", Value = "Documents" },
        };
    }

    [ObservableProperty]
    private ObservableCollection<IRadioButtonModel> _inspTypeList;

    [ObservableProperty]
    private ObservableCollection<IRadioButtonModel> _inspTypeList2;

    [ObservableProperty]
    private string _inspType;
}
