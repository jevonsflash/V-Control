using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using VControl.Controls.VCalendar;

namespace VControl.Controls;

public enum SelectionMode
{

    Range,
    Single,
    Multiple
}

public partial class VDatePicker : ContentView
{
    bool _suppressSelectionChangeNotification;
    int _selectRangeStage = 0;
    public event EventHandler<IList<DateTime>> OnFinishedSelected;
    private ChinaDateServer ChinaDateServer = new ChinaDateServer();

    private CalendarModel _calendar;
    private bool _selectRangeComplementFlag;
    private DateTime _selectRangeStartDate
        ;

    public VDatePicker()
    {
        InitializeComponent();
        Init();

    }


    public static readonly BindableProperty SelectionChangedCommandProperty =
BindableProperty.Create(nameof(SelectionChangedCommand), typeof(ICommand), typeof(VDatePicker));


    public static readonly BindableProperty SelectionChangedCommandParameterProperty =
BindableProperty.Create(nameof(SelectionChangedCommandParameter), typeof(object), typeof(VDatePicker));


    public static readonly BindableProperty NextCommandProperty =
BindableProperty.Create(nameof(NextCommand), typeof(ICommand), typeof(VDatePicker));

    public static readonly BindableProperty PriorCommandProperty =
BindableProperty.Create(nameof(PriorCommand), typeof(ICommand), typeof(VDatePicker));





    public static readonly BindableProperty SelectedDateProperty =
    BindableProperty.Create(nameof(SelectedDate),
            typeof(DateTime), typeof(VDatePicker),
            DateTime.Today, BindingMode.TwoWay, propertyChanged: OnSelectedDatePropertyChanged);

    private static void OnSelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VDatePicker).Init();
    }


    public static readonly BindableProperty SelectedDatesProperty = BindableProperty.Create(
      nameof(SelectedDates),
      typeof(IList<DateTime>),
      typeof(VDatePicker),
      null,

      defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedDatesPropertyChanged);

    private static void OnSelectedDatesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue == default)
        {
            return;
        }

        else
        {
            (bindable as VDatePicker).Init();
        }
    }


    public static readonly BindableProperty SelectionModeProperty =
        BindableProperty.Create(nameof(SelectionMode), typeof(SelectionMode), typeof(VDatePicker),
            SelectionMode.Single);


    private void Init()
    {
        if (_suppressSelectionChangeNotification)
        {
            return;
        }

        _calendar = new CalendarModel(SelectedDate);
        Refresh();
        SetDaysOfWeekNames();
    }

    public SelectionMode SelectionMode
    {
        get => (SelectionMode)GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }


    public DateTime SelectedDate
    {
        get { return (DateTime)GetValue(SelectedDateProperty); }
        set { SetValue(SelectedDateProperty, value); }
    }


    public IList<DateTime> SelectedDates
    {
        get => (IList<DateTime>)GetValue(SelectedDatesProperty);
        set => SetValue(SelectedDatesProperty, value);
    }

    public ICommand SelectionChangedCommand
    {
        get => (ICommand)GetValue(SelectionChangedCommandProperty);
        set => SetValue(SelectionChangedCommandProperty, value);
    }

    public object SelectionChangedCommandParameter
    {
        get => GetValue(SelectionChangedCommandParameterProperty);
        set => SetValue(SelectionChangedCommandParameterProperty, value);
    }



    public ICommand NextCommand
    {
        get => (ICommand)GetValue(NextCommandProperty);
        set => SetValue(NextCommandProperty, value);
    }


    public ICommand PriorCommand
    {
        get => (ICommand)GetValue(PriorCommandProperty);
        set => SetValue(PriorCommandProperty, value);
    }


    private void MakeCalendar(DayModel[,] e)
    {


        for (int i = 0; i < e.GetLength(0); i++)
        {
            SetItem(SunLayout, i, 0, e);
            SetItem(MonLayout, i, 1, e);
            SetItem(TueLayout, i, 2, e);
            SetItem(WedLayout, i, 3, e);
            SetItem(ThuLayout, i, 4, e);
            SetItem(FriLayout, i, 5, e);
            SetItem(SatLayout, i, 6, e);
        }


    }



    private void Refresh()
    {
        MakeCalendar(_calendar.CurrentCalendar);
        var currentMonth = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedMonthNames[_calendar.CurrentMonth - 1];
        MonthYearLabel.Text = $"{currentMonth}/ {_calendar.CurrentYear} ";
    }


    private void SetItem(StackLayout stk, int line, int col, DayModel[,] calendar)
    {
        DayModel model;
        if (calendar[line, col] != null)
        {
            model = calendar[line, col];
            (stk.Children[line] as VCalendarItem).IsEnabled = true;
            (stk.Children[line] as VCalendarItem).Text = GetText(model);
            (stk.Children[line] as VCalendarItem).ChinaDateText = GetChinaDateText(model);
            if (this.SelectedDates != null)
            {
                var isSelected = this.SelectedDates.Any(c => DateTime.Equals(c.Date, model.Date.Date));
                (stk.Children[line] as VCalendarItem).IsSelected = isSelected;
            }
            (stk.Children[line] as VCalendarItem).DayModel = model;

        }
        else
        {
            (stk.Children[line] as VCalendarItem).Text = "";
            (stk.Children[line] as VCalendarItem).ChinaDateText = "";
            (stk.Children[line] as VCalendarItem).IsEnabled = false;
            (stk.Children[line] as VCalendarItem).IsSelected = false;

        }




    }


    public string GetText(DayModel DayModel)
    {

        if (DayModel.Date != default)
            return DayModel.Date.Day.ToString();
        return " ";

    }

    public string GetChinaDateText(DayModel DayModel)
    {

        if (DayModel.Date != default)
            return ChinaDateServer.GetDay(DayModel.Date);
        return " ";

    }

    protected void Tpl_OnSelected(object sender, DayModel dayModel)
    {
        var calendarItem = sender as VCalendarItem;
        _suppressSelectionChangeNotification = true;
        if (this.SelectionMode == SelectionMode.Multiple)
        {
            if (dayModel.Date != default)
            {
                if (calendarItem.IsSelected)
                {
                    this.SelectedDates?.Add(dayModel.Date);
                    this.SelectedDate = dayModel.Date;
                }
                else
                {
                    this.SelectedDates?.Remove(dayModel.Date);
                    this.SelectedDate = default;

                }

                this.OnFinishedSelected?.Invoke(this, this.SelectedDates);


                var command = this.SelectionChangedCommand;
                if (command != null)
                {
                    var commandParameter = SelectionChangedCommandParameter;

                    if (command.CanExecute(commandParameter))
                    {
                        command.Execute(commandParameter);
                    }
                }

            }
        }
        else if (this.SelectionMode == SelectionMode.Single)
        {
            if (dayModel.Date != default)
            {
                if (calendarItem.IsSelected)
                {
                    this.SelectedDates?.Clear();
                    SetAllSelected(false);
                    this.SelectedDates?.Add(dayModel.Date);
                    this.SelectedDate = dayModel.Date;
                    this.SetSelected(dayModel.Position, true);
                }
                else
                {
                    this.SelectedDates?.Remove(dayModel.Date);
                    this.SelectedDate = default;

                }


                SetSelected(dayModel.Position, true);

                this.SelectedDate = dayModel.Date;

                this.OnFinishedSelected?.Invoke(this, this.SelectedDates);


                var command = this.SelectionChangedCommand;
                if (command != null)
                {
                    var commandParameter = SelectionChangedCommandParameter;

                    if (command.CanExecute(commandParameter))
                    {
                        command.Execute(commandParameter);
                    }
                }

            }
        }

        else if (this.SelectionMode == SelectionMode.Range)
        {
            if (dayModel.Date != default)
            {
                if (_selectRangeStage == 0)
                {
                    this.SelectedDates?.Clear();
                    SetAllSelected(false);
                    this._selectRangeStartDate = dayModel.Date;
                    this.SetSelected(dayModel.Position, true);

                    _selectRangeStage = 1;

                }
                else if (_selectRangeStage == 1)
                {

                    var startDate = _selectRangeStartDate;
                    if (_selectRangeStartDate != default)
                    {
                        if (dayModel.Date < startDate)
                        {
                            SetAllSelected(false);
                            this._selectRangeStartDate = dayModel.Date;
                            this.SetSelected(dayModel.Position, true);

                            return;
                        }


                        for (int line = 0; line < _calendar.CurrentCalendar.GetLength(0); line++)
                        {
                            for (int col = 0; col < _calendar.CurrentCalendar.GetLength(1); col++)
                            {
                                var currentDayModel = _calendar.CurrentCalendar[line, col];
                                if (currentDayModel != null)
                                {
                                    var currentDate = currentDayModel.Date;
                                    if (dayModel.Date >= currentDate && currentDate > startDate)
                                    {
                                        if (!_selectRangeComplementFlag)
                                        {
                                            for (DateTime date = startDate; date < currentDate; date = date.AddDays(1))
                                            {
                                                this.SelectedDates?.Add(date);
                                            }
                                            _selectRangeComplementFlag = true;
                                        }
                                        SetSelected(currentDayModel.Position, true);
                                        this.SelectedDates?.Add(currentDate);
                                        this.SelectedDate = currentDate;
                                    }
                                }
                            }

                        }
                        _selectRangeStage = 0;
                        _selectRangeComplementFlag = false;
                        _selectRangeStartDate = default;

                        this.OnFinishedSelected?.Invoke(this, this.SelectedDates);


                        var command = this.SelectionChangedCommand;
                        if (command != null)
                        {
                            var commandParameter = SelectionChangedCommandParameter;

                            if (command.CanExecute(commandParameter))
                            {
                                command.Execute(commandParameter);
                            }
                        }

                    }

                }

                this.SelectedDate = dayModel.Date;
            }
        }


        _suppressSelectionChangeNotification = false;

    }

    private void SetSelected((int i, int j) pos, bool isSelected, bool isInvolved = false)
    {
        var line = pos.i;
        switch (pos.j)
        {
            case 0:
                (SunLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (SunLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 1:
                (MonLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (MonLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 2:
                (TueLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (TueLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 3:
                (WedLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (WedLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 4:
                (ThuLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (ThuLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 5:
                (FriLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (FriLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            case 6:
                (SatLayout.Children[line] as VCalendarItem).IsSelected = isSelected;
                (SatLayout.Children[line] as VCalendarItem).IsInvolved = isInvolved;
                break;
            default:
                break;
        }
    }

    private bool GetSelected((int i, int j) pos)
    {
        var line = pos.i;
        var isSelected = false;
        switch (pos.j)
        {
            case 0:
                isSelected = (SunLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 1:
                isSelected = (MonLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 2:
                isSelected = (TueLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 3:
                isSelected = (WedLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 4:
                isSelected = (ThuLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 5:
                isSelected = (FriLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            case 6:
                isSelected = (SatLayout.Children[line] as VCalendarItem).IsSelected;
                break;
            default:
                break;
        }
        return isSelected;
    }

    public List<DayModel> SetAllSelected(bool isSelected)
    {
        var selectedDates = new List<DayModel>();

        for (int i = 0; i < _calendar.CurrentCalendar.GetLength(0); i++)
        {
            for (int j = 0; j < _calendar.CurrentCalendar.GetLength(1); j++)
            {
                SetSelected((i, j), isSelected);
            }
        }

        return selectedDates;
    }

    private void SetDaysOfWeekNames()
    {
        SunLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0];
        MonLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[1];
        TueLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[2];
        WedLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[3];
        ThuLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[4];
        FriLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[5];
        SatLabel.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[6];
    }

    private void Prior_ClickedButton(object sender, EventArgs e)
    {
        _calendar.PriorMonth();
        Refresh();
    }

    private void Next_ClickedButton(object sender, EventArgs e)
    {
        _calendar.NextMonth();
        Refresh();
    }
}
