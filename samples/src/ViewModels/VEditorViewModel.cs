using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VEditorViewModel : ViewModelBase
{
    public VEditorViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VEditor Samples";
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;
}
