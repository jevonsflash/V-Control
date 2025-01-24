using System.Collections.ObjectModel;
using VControl.Controls;
using VControl.Controls.VExpandable;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VRadioButtonViewModel : ViewModelBase
{
    public VRadioButtonViewModel(INavigationService navService)
        : base(navService) { }
}
