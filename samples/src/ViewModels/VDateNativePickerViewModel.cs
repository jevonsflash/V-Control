using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VDateNativePickerViewModel : ViewModelBase
{
    public VDateNativePickerViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VDateNativePickerView Samples";
    }

    [ObservableProperty]
    private bool _isExpanded = true;
}
