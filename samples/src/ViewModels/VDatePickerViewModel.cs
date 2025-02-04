using System.Collections.ObjectModel;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VDatePickerViewModel : ViewModelBase
{
    public VDatePickerViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VDatePicker Samples";
        DateRangeList = new ObservableCollection<string>()
        {
            "Customized",
            "Today",
            "The last 3 days",
            "The next 3 days",
            "The recent week",
            "The next week",
            "The recent month",
            "The next month",
        };

        this.PropertyChanged += VDatePickerViewModel_PropertyChanged;
    }

    [ObservableProperty]
    private ObservableCollection<DateTime> _dates = new ObservableCollection<DateTime>();

    [ObservableProperty]
    private DateTime? _currentDate = DateTime.Today;

    [ObservableProperty]
    private DateTime? _startDate;

    [ObservableProperty]
    private DateTime? _endDate;

    [ObservableProperty]
    private bool _isSelect;

    [ObservableProperty]
    private VControl.Controls.SelectionMode _selectionMode;

    [ObservableProperty]
    public ObservableCollection<string> _dateRangeList;

    [ObservableProperty]
    private string _selectedDate;

    private void VDatePickerViewModel_PropertyChanged(
        object sender,
        System.ComponentModel.PropertyChangedEventArgs e
    )
    {
        if (e.PropertyName == nameof(SelectedDate))
        {
            UpdateDateTime(SelectedDate);
            if (StartDate != default && EndDate != default)
            {
                var newDates = new List<DateTime>();
                for (DateTime date = StartDate.Value; date <= EndDate; date = date.AddDays(1))
                {
                    newDates.Add(date);
                }
                this.Dates = new ObservableCollection<DateTime>(newDates);
            }
            else
            {
                this.Dates = new ObservableCollection<DateTime>();
            }
        }
    }

    [RelayCommand]
    public void DateRangeSelectionChanged()
    {
        if (Dates != null)
        {
            if (!Dates.Any())
            {
                SelectedDate = null;
                this.Dates = new ObservableCollection<DateTime>();
            }
            else
            {
                if (Dates.Count > 0)
                {
                    this.StartDate = Dates.FirstOrDefault();
                    this.EndDate = Dates.LastOrDefault();
                }
                SelectedDate = DateRangeList?.FirstOrDefault();
            }
        }
    }

    private void UpdateDateTime(string tempDateRange)
    {
        var now = DateTime.Now;
        if (string.IsNullOrEmpty(tempDateRange))
        {
            StartDate = default;
            EndDate = default;
        }
        else
        {
            switch (tempDateRange)
            {
                case "Today":
                    StartDate = now;
                    EndDate = now;
                    break;
                case "The last 3 days":
                    StartDate = now.AddDays(-3);
                    EndDate = now.AddDays(-1);
                    break;
                case "The next 3 days":
                    StartDate = now.AddDays(1);
                    EndDate = now.AddDays(3);
                    break;
                case "The recent week":
                    StartDate = now.AddDays(-7);
                    EndDate = now.AddDays(-1);
                    break;
                case "The next week":
                    StartDate = now.AddDays(1);
                    EndDate = now.AddDays(7);
                    break;
                case "The recent month":
                    StartDate = now.AddDays(-30);
                    EndDate = now.AddDays(-1);
                    break;
                case "The next month":
                    StartDate = now.AddDays(1);
                    EndDate = now.AddDays(30);
                    break;
            }
        }
    }
}
