using System.Collections.ObjectModel;
using VControl.Samples.Common;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCheckableCollectionViewModel : ViewModelBase
{
    public VCheckableCollectionViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VTouchContentView Samples";
        CollectionModel1 = new EmailCheckableCollectionModel();
        CollectionModel2 = new EmailCheckableCollectionModel();
        CollectionModel3 = new EmailCheckableCollectionModel();
    }

    [ObservableProperty]
    private EmailCheckableCollectionModel _collectionModel1;

    [ObservableProperty]
    private EmailCheckableCollectionModel _collectionModel2;

    [ObservableProperty]
    private EmailCheckableCollectionModel _collectionModel3;
}
