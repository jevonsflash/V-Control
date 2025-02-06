using System.Collections.ObjectModel;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCheckBoxGroupViewModel : ViewModelBase
{
    public VCheckBoxGroupViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VCheckBoxGroupView Samples";

        CityList = new ObservableCollection<string>()
        {
            "Austin",
            "Washington",
            "Denver",
            "Chicago",
            "Seattle",
            "New York",
            "Los Angeles",
        };

        CollectionModel1 = new EmailCheckableCollectionModel();
    }

    [ObservableProperty]
    public ObservableCollection<string> _cityList;

    [ObservableProperty]
    private EmailCheckableCollectionModel _collectionModel1;
}
