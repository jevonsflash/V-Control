using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VButtonViewModel : ViewModelBase
{

    public VButtonViewModel(
        INavigationService navService)

        : base(navService)
    {
        this.PageTitle = "VButton Samples";
    }

    [ObservableProperty]
    private bool _isLoading;

}
