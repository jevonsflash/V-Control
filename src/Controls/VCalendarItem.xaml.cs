using System.Windows.Input;
using VControl.Controls.VCalendar;

namespace VControl.Controls
{
    public partial class VCalendarItem : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(VCalendarItem),
            "N/A"
        );

        public static readonly BindableProperty ChinaDateTextProperty = BindableProperty.Create(
            nameof(ChinaDateText),
            typeof(string),
            typeof(VCalendarItem),
            "N/A"
        );

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(VCalendarItem),
            default(ICommand),
            propertyChanging: (bindable, oldvalue, newvalue) =>
            {
                var vCalendarItem = (VCalendarItem)bindable;
                var oldcommand = (ICommand)oldvalue;
                if (oldcommand != null)
                    oldcommand.CanExecuteChanged -= vCalendarItem.OnCommandCanExecuteChanged;
            },
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var vCalendarItem = (VCalendarItem)bindable;
                var newcommand = (ICommand)newvalue;
                if (newcommand != null)
                {
                    vCalendarItem.IsEnabled = newcommand.CanExecute(vCalendarItem.CommandParameter);
                    newcommand.CanExecuteChanged += vCalendarItem.OnCommandCanExecuteChanged;
                }
            }
        );

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(VCalendarItem),
            default(object),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var vCalendarItem = (VCalendarItem)bindable;
                if (vCalendarItem.Command != null)
                {
                    vCalendarItem.IsEnabled = vCalendarItem.Command.CanExecute(newvalue);
                }
            }
        );

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(
            nameof(SelectedColor),
            typeof(Color),
            typeof(VCalendarItem),
            Colors.Gray
        );

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(VCalendarItem),
            false,
            BindingMode.TwoWay,
            propertyChanged: OnIsSelectedPropertyChanged
        );

        public static readonly BindableProperty IsInvolvedProperty = BindableProperty.Create(
            nameof(IsInvolved),
            typeof(bool),
            typeof(VCalendarItem),
            false,
            BindingMode.TwoWay,
            propertyChanged: OnIsInvolvedPropertyChanged
        );

        public static readonly BindableProperty DayModelProperty = BindableProperty.Create(
            nameof(DayModel),
            typeof(DayModel),
            typeof(VCalendarItem),
            null
        );

        public VCalendarItem()
        {
            InitializeComponent();
            GoToState(IsSelected);
        }

        public event EventHandler Clicked;

        public event EventHandler<DayModel> OnSelected;

        public string ChinaDateText
        {
            get => (string)GetValue(ChinaDateTextProperty);
            set => SetValue(ChinaDateTextProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public bool IsInvolved
        {
            get { return (bool)GetValue(IsInvolvedProperty); }
            set { SetValue(IsInvolvedProperty, value); }
        }

        public DayModel DayModel
        {
            get { return (DayModel)GetValue(DayModelProperty); }
            set { SetValue(DayModelProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public void GoToState(bool isSelected)
        {
            string visualState = isSelected ? "IsSelected" : "Normal";
            VisualStateManager.GoToState(this, visualState);
        }

        public void GoToInvolvedState(bool isInvolved)
        {
            if (isInvolved)
            {
                VisualStateManager.GoToState(this, "IsInvolved");
            }
            else
            {
                GoToState(this.IsSelected);
            }
        }

        internal void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            IsEnabled = Command.CanExecute(CommandParameter);
        }

        private static void OnIsSelectedPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue
        )
        {
            var vCalendarItem = (VCalendarItem)bindable;
            if (newValue != oldValue)
            {
                vCalendarItem.GoToState((bool)newValue);
            }
        }

        private static void OnIsInvolvedPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue
        )
        {
            var vCalendarItem = (VCalendarItem)bindable;
            vCalendarItem.GoToInvolvedState((bool)newValue);
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            IsSelected = !IsSelected;
            if (!IsEnabled)
            {
                return;
            }

            OnSelected?.Invoke(this, DayModel);

            Command?.Execute(CommandParameter);
            GoToState(IsSelected);
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
