using System.Collections.ObjectModel;
using VControl.Controls.VExpandable;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VTopAppBarViewModel : ViewModelBase
{

    public VTopAppBarViewModel(
        INavigationService navService)

        : base(navService)
    {

    }
    [ObservableProperty]
    private double _progress;

    [ObservableProperty]
    private bool _isLoading;

    [RelayCommand]
    private async Task MoreAsync(object obj)
    {
       await this.AlertOkayAsync(obj.ToString());
    }

}
