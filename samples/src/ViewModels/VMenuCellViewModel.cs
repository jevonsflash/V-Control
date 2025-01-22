using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VMenuCellViewModel : ViewModelBase
{

    public VMenuCellViewModel(
        INavigationService navService)

        : base(navService)
    {
        this.PageTitle = "VMenuCell Samples";
    }

    [ObservableProperty]
    private bool _isLoading;


}
