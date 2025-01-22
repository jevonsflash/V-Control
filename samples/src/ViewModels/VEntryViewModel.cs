using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VEntryViewModel : ViewModelBase
{

    public VEntryViewModel(
        INavigationService navService)

        : base(navService)
    {
        this.PageTitle = "VEntry Samples";
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;

}
