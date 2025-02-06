using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VFormItemViewModel : ViewModelBase
{
    public VFormItemViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VFormItemView Samples";
    }

    [ObservableProperty]
    private bool _hasInfo = true;

    [ObservableProperty]
    private bool _hasTitle = true;

    [ObservableProperty]
    private bool _isInvalid = true;
}
