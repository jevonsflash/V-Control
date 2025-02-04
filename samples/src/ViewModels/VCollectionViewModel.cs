using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCollectionViewModel : ViewModelBase
{
   
    [ObservableProperty]
    private bool _isExpanded = true;

    public VCollectionViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VCollectionView Samples";
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

