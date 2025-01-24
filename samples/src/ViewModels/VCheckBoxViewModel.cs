using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCheckBoxViewModel : ViewModelBase
{
    public VCheckBoxViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VButton Samples";
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;
}
