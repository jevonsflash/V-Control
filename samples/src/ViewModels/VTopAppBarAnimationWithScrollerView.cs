using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class AnimationWithScrollerViewModel : ViewModelBase
{

    public AnimationWithScrollerViewModel(
        INavigationService navService)
       
        : base(navService)
    {
        
    }

}
