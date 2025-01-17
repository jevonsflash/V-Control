using System.Collections.ObjectModel;
using VControl.Controls.VExpandable;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VRadioButtonViewModel : ViewModelBase
{

    public VRadioButtonViewModel(
        INavigationService navService)

        : base(navService)
    {
        InspTypeList = new ObservableCollection<IRadioButtonModel>(){
            new RadioButtonModel(){    Id="1", Value="Booking", Icon="\uF0eb"}
        ,new RadioButtonModel(){ Id="2", Value="Reports", Icon="\uF0eb"}};
        this.InspType = InspTypeList.FirstOrDefault().Id;

        InspTypeList2 = new ObservableCollection<IRadioButtonModel>(){
            new RadioButtonModel(){    Id="1", Value="Booking"}
        ,new RadioButtonModel(){ Id="2", Value="Reports"}};
        this.InspType2 = InspTypeList2.FirstOrDefault().Id;
    }

    [ObservableProperty]
    private ObservableCollection<IRadioButtonModel> _inspTypeList;

    [ObservableProperty]
    private string _inspType;

    [ObservableProperty]
    private ObservableCollection<IRadioButtonModel> _inspTypeList2;

    [ObservableProperty]
    private string _inspType2;

}
