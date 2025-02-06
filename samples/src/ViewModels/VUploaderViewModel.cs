using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VUploaderViewModel : ViewModelBase
{
    public VUploaderViewModel(INavigationService navService)
        : base(navService) { }
}
