using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VPlaceholderViewViewModel : ViewModelBase
{
    public VPlaceholderViewViewModel(INavigationService navService)
        : base(navService) { }
}
