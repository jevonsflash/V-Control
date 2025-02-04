using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using VControl.Samples.Common;
using VControl.Samples.Models;

namespace VControl.Samples.ViewModels;

public partial class EmailCheckableCollectionModel : ObservableObject
{
    public EmailCheckableCollectionModel()
    {
        EmailList = new ObservableCollection<PickerM>(
            CommonHelper.GenerateRandomNamesAndEmails(10)
        );
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
                    : this
                        .EmailList.Where(c =>
                            !string.IsNullOrEmpty(c.Title)
                            && c.Title.Contains(
                                this.SearchKeywords,
                                StringComparison.OrdinalIgnoreCase
                            )
                        )
                        .ToList();
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

    [RelayCommand]

    private async Task RemoveEmail(object obj)
    {
        var toast = Toast.Make("Remove Button Clicked: "+(obj as PickerM).Value, ToastDuration.Long);
        await toast.Show();

    }

    [RelayCommand]

    private async Task EditEmail(object obj)
    {
        var toast = Toast.Make("Edit Button Clicked:" + (obj as PickerM).Value, ToastDuration.Long);
        await toast.Show();
    }

}
