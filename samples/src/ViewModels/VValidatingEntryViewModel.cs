using System.Collections.ObjectModel;
using VControl.Controls.Validations;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VValidatingEntryViewModel : ViewModelBase
{
    public VValidatingEntryViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VValidatingEntry Samples";
        AddValidations();


    }

    [ObservableProperty]
    private bool _isIndeterminate = true;


    [ObservableProperty]
    private ValidatableObject<string> _contactName = new();


    [ObservableProperty]
    private ValidatableObject<string> _email = new();

    [ObservableProperty]
    private ValidatableObject<string> _userName = new();


    [ObservableProperty]
    private ValidatableObject<string> _password = new();



    [ObservableProperty]
    private ValidatableObject<string> _companyName = new();



    [RelayCommand]
    private void ValidateUserName(object obj)
    {
        if (UserName.Value != null && !string.IsNullOrEmpty(UserName.Value))
        {
            UserName.IsValid = true;
        }
        else
        {
            UserName.IsValid = false;
            UserName.Errors = new List<string>() { "UserName is required." };
        }
    }

   


    private void AddValidations()
    {
        ContactName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Contact Name is required." });
        Email.Validations.Add(new IsEmailRule<string> { ValidationMessage = "Email is invalid." });
        UserName.Validations.Add(new IsUserNameOrEmailRule<string> { ValidationMessage = "UserName is invalid." });
        Password.Validations.Add(new MinCountOfDigitRule<string>() { ValidationMessage = "The password must contain at least one digit." });
        Password.Validations.Add(new MaxLenRule<string>(16) { ValidationMessage = "The password cannot exceed 16 characters in length." });
        Password.Validations.Add(new MinLenRule<string>(8) { ValidationMessage = "The password must be at least 8 characters long." });
        Password.Validations.Add(new MinCountOfUpperLetterRule<string> { ValidationMessage = "The password must contain at least one uppercase letter." });


        CompanyName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Company Name is required." });
    }

}
