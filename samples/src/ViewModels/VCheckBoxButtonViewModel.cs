using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCheckBoxButtonViewModel : ViewModelBase
{
    public VCheckBoxButtonViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VCheckBoxButtonView Samples";
    }

    [ObservableProperty]
    private bool _isExpanded = true;
}
