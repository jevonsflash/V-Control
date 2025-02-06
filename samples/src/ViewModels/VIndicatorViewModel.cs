using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VIndicatorViewModel : ViewModelBase
{
    public VIndicatorViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VIndicatorView Samples";
    }

    [ObservableProperty]
    private bool _isExpanded = true;
}
