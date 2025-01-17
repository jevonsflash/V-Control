using System.Collections.ObjectModel;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VTouchContentViewViewModel : ViewModelBase
{

    public VTouchContentViewViewModel(
        INavigationService navService)

        : base(navService)
    {
        this.PageTitle = "VTouchContentView Samples";
        _debugMessages = new ObservableCollection<string>() { "-----------Start------------" };
    }
    [ObservableProperty]
    private ObservableCollection<string> _debugMessages;

}
