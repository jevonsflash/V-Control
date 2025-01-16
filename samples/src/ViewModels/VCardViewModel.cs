using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCardViewModel : ViewModelBase
{

    public VCardViewModel(
        INavigationService navService)
       
        : base(navService)
    {
        
    }

}
