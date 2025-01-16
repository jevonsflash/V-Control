using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class StyleSamplesViewModel : ViewModelBase
{

    public StyleSamplesViewModel(
        INavigationService navService)
       
        : base(navService)
    {
       
    }

}
