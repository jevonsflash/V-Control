using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VExpanderViewModel : ViewModelBase
{
    public VExpanderViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VExpanderView Samples";
    }

    [ObservableProperty]
    private bool _isExpanded = true;
}
