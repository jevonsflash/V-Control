using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VNumberEntryViewModel : ViewModelBase
{
    public VNumberEntryViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VNumberEntryView Samples";
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;
}
