using System.Collections.ObjectModel;
using VControl.Samples.Common;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VCheckableCollectionViewModel : ViewModelBase
{

    public VCheckableCollectionViewModel(
        INavigationService navService)

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


public partial class EmailCheckableCollectionModel : ObservableObject
{

    public EmailCheckableCollectionModel()
    {
        EmailList = new ObservableCollection<PickerM>(CommonHelper.GenerateRandomNamesAndEmails(10));
    }
    private IList<PickerM> emailList;

    public IList<PickerM> EmailList
    {
        get { return emailList; }
        set
        {
            emailList = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(InternalEmailList));
        }
    }


    public IList<PickerM> InternalEmailList
    {
        get
        {
            if (EmailList != null)
            {
                IList<PickerM> list = string.IsNullOrEmpty(SearchKeywords)
               ? this.EmailList
               : this.EmailList.Where(c => !string.IsNullOrEmpty(c.Title) && c.Title.Contains(this.SearchKeywords, StringComparison.OrdinalIgnoreCase)).ToList();
                return list;
            }
            return EmailList;

        }
    }

    private string _searchKeywords;

    public string SearchKeywords
    {
        get { return _searchKeywords; }
        set
        {
            _searchKeywords = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(InternalEmailList));
        }
    }

    [ObservableProperty]
    private ObservableCollection<PickerM> _selectedEmailList = new();

    [ObservableProperty]
    private bool _hasClear = true;
    [ObservableProperty]
    private bool _isCollectionEnabled = true;

    [ObservableProperty]
    private bool _hasSearchBar = true;


    [ObservableProperty]
    private string _displayPropertyName = "Title";

}
