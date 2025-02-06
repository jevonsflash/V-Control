using System.Collections.ObjectModel;
using VControl.Controls.Validations;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VValidatingPickerViewModel : ViewModelBase
{
    public VValidatingPickerViewModel(INavigationService navService)
        : base(navService)
    {
        this.SalutationList = new()
        {
            new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Value = "-NULL-" },
            },
            new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Id = "1", Value = "Mr." },
            },
            new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Id = "2", Value = "Ms." },
            },
            new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Id = "3", Value = "Mrs." },
            },
            new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Id = "4", Value = "Miss." },
            },
        };

        var rules = new List<IValidationRule<PickerM>>() {
            new MoreThanRule<PickerM>(18, true) { ValidationMessage = "You must be over 18 years old" },
            new LessThanRule<PickerM>(21, false) { ValidationMessage = "You must be under 21 years old" }
        };
        this.AgeList = new();
        for (int i = 14; i < 23; i++)
        {

            AgeList.Add(new ValidatableObject<PickerM>()
            {
                Value = new PickerM { Value = i.ToString() },
                Validations = rules
            });
        }

    }

    [ObservableProperty]
    private ObservableCollection<ValidatableObject<PickerM>> _salutationList;

    [ObservableProperty]
    private ValidatableObject<PickerM> _selectedSalutation = new();


    [ObservableProperty]
    private ObservableCollection<ValidatableObject<PickerM>> _ageList;

    [ObservableProperty]
    private ValidatableObject<PickerM> _selectedAge = new();

    [RelayCommand]
    private void ValidateSalutation()
    {

        if (SelectedSalutation.Value != null && !string.IsNullOrEmpty(SelectedSalutation.Value.Id))
        {
            return;
        }
        SelectedSalutation.IsValid = false;
        SelectedSalutation.Errors = ["Title is required."];

    }
}
