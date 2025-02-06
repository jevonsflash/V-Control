using System.Collections.ObjectModel;
using System.ComponentModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VTagPickerViewModel : ViewModelBase
{
    public VTagPickerViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VTagPickerView Samples";

        DesCountryList = new ObservableCollection<PickerM>()
        {
            new PickerM { Id = "US", Value = "United States" },
            new PickerM { Id = "CN", Value = "China" },
            new PickerM { Id = "JP", Value = "Japan" },
            new PickerM { Id = "DE", Value = "Germany" },
            new PickerM { Id = "FR", Value = "France" },
            new PickerM { Id = "GB", Value = "United Kingdom" },
            new PickerM { Id = "RU", Value = "Russia" },
            new PickerM { Id = "IN", Value = "India" },
            new PickerM { Id = "CA", Value = "Canada" },
            new PickerM { Id = "AU", Value = "Australia" },
        };

        DesCountryList2 = new ObservableCollection<PickerM>()
        {
            new PickerM { Id = "US", Value = "United States" },
            new PickerM { Id = "CN", Value = "China" },
            new PickerM { Id = "JP", Value = "Japan" },
        };

        this.PropertyChanged += VTagPickerViewModel_PropertyChanged;
    }

    private void VTagPickerViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(VTagPickerViewModel.SelectedCountry))
        {
            this.SelectedCountryList.Add(SelectedCountry);
        }
    }

    [ObservableProperty]
    private bool _isIndeterminate = true;

    [ObservableProperty]
    private ObservableCollection<PickerM> _desCountryList;

    [ObservableProperty]
    private ObservableCollection<PickerM> _desCountryList2;

    [ObservableProperty]
    private ObservableCollection<PickerM> _selectedCountryList = new();

    [ObservableProperty]
    private PickerM _selectedCountry;

    [ObservableProperty]
    private string _displayPropertyName = "Value";

    [RelayCommand]
    private void RemoveDesCountry(object obj)
    {
        if (obj != null && obj is PickerM)
        {
            SelectedCountryList.Remove(obj as PickerM);
        }
    }
}
