using System.Collections.ObjectModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VPickerViewModel : ViewModelBase
{

    public VPickerViewModel(INavigationService navService)
        : base(navService)
    {
        this.SalutationList = new()
        {
            new PickerM { Value = "-NULL-" },
           new PickerM { Id = "1", Value = "Mr." },
            new PickerM { Id = "2", Value = "Ms." },
        new  PickerM { Id = "3", Value = "Mrs." },
        new PickerM { Id = "4", Value = "Miss." },

        };


        this.AgeList = new();
        for (int i = 14; i < 23; i++)
        {

            AgeList.Add(new PickerM { Value = i.ToString() }
            );
        }

    }

    [ObservableProperty]
    private ObservableCollection<PickerM> _salutationList;

    [ObservableProperty]
    private PickerM _selectedSalutation = new();


    [ObservableProperty]
    private ObservableCollection<PickerM> _ageList;

    [ObservableProperty]
    private PickerM _selectedAge = new();
    [ObservableProperty]
    private string _displayPropertyName = "Value";

}

