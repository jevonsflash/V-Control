namespace VControl.Controls;

public partial class VDateNativePicker : ContentView
{
    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
        nameof(SelectedDate),
        typeof(DateTime),
        typeof(VDateNativePicker),
        DateTime.Today,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty MinDateProperty = BindableProperty.Create(
        nameof(MinDate),
        typeof(DateTime),
        typeof(VDateNativePicker),
        new DateTime(1900, 1, 1),
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty MaxDateProperty = BindableProperty.Create(
        nameof(MaxDate),
        typeof(DateTime),
        typeof(VDateNativePicker),
        new DateTime(2100, 12, 31),
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty IsPickerEnabledProperty = BindableProperty.Create(
        nameof(IsPickerEnabled),
        typeof(bool),
        typeof(VDateNativePicker),
        true,
        //propertyChanged: OnEntryTextPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public DateTime SelectedDate
    {
        get => (DateTime)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }

    public DateTime MinDate
    {
        get => (DateTime)GetValue(MinDateProperty);
        set => SetValue(MinDateProperty, value);
    }

    public DateTime MaxDate
    {
        get => (DateTime)GetValue(MaxDateProperty);
        set => SetValue(MaxDateProperty, value);
    }

    public bool IsPickerEnabled
    {
        get => (bool)GetValue(IsPickerEnabledProperty);
        set => SetValue(IsPickerEnabledProperty, value);
    }

    public VDateNativePicker()
    {
        InitializeComponent();
    }
}
