using System.Windows.Input;

namespace VControl.Controls;

public partial class VNumberEntry : ContentView
{
    public event EventHandler<ValueChangedEventArgs> ValueChanged;

    public VNumberEntry()
    {
        InitializeComponent();
        IncreaseButton.IsEnabled = Value < Maximum;
        DecreaseButton.IsEnabled = Value > Minimum;
        Loaded += VNumberEntry_Loaded;
    }

    private void VNumberEntry_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            this.MainContent.Content = (View)this.ContentSlot;
        }
        if (string.IsNullOrEmpty(EntryIconText))
        {
            HasIconText = false;
        }
        else
        {
            HasIconText = true;
        }
    }

    public static readonly BindableProperty DigitsProperty = BindableProperty.Create(
        nameof(Digits),
        typeof(int),
        typeof(VNumberEntry),
        0,
        propertyChanged: OnDigitsPropertyChanged
    );

    private static void OnDigitsPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    ) { }

    public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
        nameof(Maximum),
        typeof(double),
        typeof(VNumberEntry),
        100.0,
        validateValue: (bindable, value) => (double)value > ((VNumberEntry)bindable).Minimum,
        coerceValue: (bindable, value) =>
        {
            var numberEntry = (VNumberEntry)bindable;
            numberEntry.Value = double.Clamp(numberEntry.Value, numberEntry.Minimum, (double)value);
            return value;
        }
    );

    /// <summary>Bindable property for <see cref="Minimum"/>.</summary>
    public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
        nameof(Minimum),
        typeof(double),
        typeof(VNumberEntry),
        0.0,
        validateValue: (bindable, value) => (double)value < ((VNumberEntry)bindable).Maximum,
        coerceValue: (bindable, value) =>
        {
            var numberEntry = (VNumberEntry)bindable;
            numberEntry.Value = double.Clamp(numberEntry.Value, (double)value, numberEntry.Maximum);
            return value;
        }
    );

    public static readonly BindableProperty IncrementProperty = BindableProperty.Create(
        nameof(Increment),
        typeof(double),
        typeof(VNumberEntry),
        1.0,
        propertyChanged: OnIncrementPropertyChanged
    );

    private static void OnIncrementPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    ) { }

    public static readonly BindableProperty HasIconTextProperty = BindableProperty.Create(
        nameof(HasIconText),
        typeof(bool),
        typeof(VNumberEntry),
        true,
        BindingMode.TwoWay
    );

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(double),
        typeof(VNumberEntry),
        0.0,
        BindingMode.TwoWay,
        coerceValue: OnCoerceValue,
        propertyChanged: OnValuePropertyChanged
    );

    private static object OnCoerceValue(BindableObject bindable, object value)
    {
        var numberEntry = (VNumberEntry)bindable;
        var newValue = double.Clamp(
            Math.Round(((double)value), numberEntry.Digits),
            numberEntry.Minimum,
            numberEntry.Maximum
        );
        return newValue;
    }

    private static void OnValuePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if (oldValue != newValue)
        {
            var numberEntry = (VNumberEntry)bindable;
            numberEntry.IncreaseButton.IsEnabled = (double)newValue < numberEntry.Maximum;
            numberEntry.DecreaseButton.IsEnabled = (double)newValue > numberEntry.Minimum;
            numberEntry.ValueChanged?.Invoke(
                numberEntry,
                new ValueChangedEventArgs((double)oldValue, (double)newValue)
            );
        }
    }

    public static readonly BindableProperty EntryIconTextProperty = BindableProperty.Create(
        nameof(EntryIconText),
        typeof(string),
        typeof(VNumberEntry),
        string.Empty,
        propertyChanged: OnEntryIconTextPropertyChanged,
        defaultBindingMode: BindingMode.OneWay
    );

    private static void OnEntryIconTextPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if (string.IsNullOrEmpty(newValue as string))
        {
            (bindable as VNumberEntry).HasIconText = false;
        }
        else
        {
            (bindable as VNumberEntry).HasIconText = true;
        }
    }

    public static readonly BindableProperty EntryPlaceholderProperty = BindableProperty.Create(
        nameof(EntryPlaceholder),
        typeof(string),
        typeof(VNumberEntry),
        "Enter number.",
        //propertyChanged: OnValuePropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty EntryIsReadOnlyProperty = BindableProperty.Create(
        nameof(EntryIsReadOnly),
        typeof(bool),
        typeof(VNumberEntry),
        false,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VNumberEntry),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vEntry = (VNumberEntry)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vEntry.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vEntry = (VNumberEntry)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                vEntry.IsEnabled = newcommand.CanExecute(vEntry.CommandParameter);
                newcommand.CanExecuteChanged += vEntry.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VNumberEntry),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vEntry = (VNumberEntry)bindable;
            if (vEntry.Command != null)
            {
                vEntry.IsEnabled = vEntry.Command.CanExecute(newvalue);
            }
        }
    );

    public IView ContentSlot { get; set; }

    public string EntryIconText
    {
        get => (string)GetValue(EntryIconTextProperty);
        set => SetValue(EntryIconTextProperty, value);
    }

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public string EntryPlaceholder
    {
        get => (string)GetValue(EntryPlaceholderProperty);
        set => SetValue(EntryPlaceholderProperty, value);
    }

    public bool EntryIsReadOnly
    {
        get => (bool)GetValue(EntryIsReadOnlyProperty);
        set => SetValue(EntryIsReadOnlyProperty, value);
    }

    public bool HasIconText
    {
        get { return (bool)GetValue(HasIconTextProperty); }
        set { SetValue(HasIconTextProperty, value); }
    }

    public double Maximum
    {
        get => (double)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public int Digits
    {
        get => (int)GetValue(DigitsProperty);
        set => SetValue(DigitsProperty, value);
    }

    public double Minimum
    {
        get => (double)GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    public double Increment
    {
        get => (double)GetValue(IncrementProperty);
        set => SetValue(IncrementProperty, value);
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

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Command?.Execute(CommandParameter);
#if IOS
        //focus is not obtained under ios, so manually focus
        (sender as Entry).Focus();
#endif
    }

    private void Decrease_ClickedButton(object sender, EventArgs e)
    {
        this.Value -= Increment;
    }

    private void Increase_ClickedButton(object sender, EventArgs e)
    {
        this.Value += Increment;
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        if (sender is Entry entry)
        {
            //issue: https://stackoverflow.com/questions/76078597/select-all-text-in-entry-when-focused
            Dispatcher.Dispatch(() =>
            {
                // ѡ�� Entry ��ȫ���ı�
                entry.CursorPosition = 0;
                entry.SelectionLength = entry.Text?.Length ?? 0;
            });
        }
    }

    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        if (sender is Entry entry)
        {
            entry.Text = Value.ToString();
        }
    }
}
