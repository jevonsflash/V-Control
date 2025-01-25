using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VSearchBarViewModel : ViewModelBase
{
    public VSearchBarViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VSearchBarView Samples";
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;
}
