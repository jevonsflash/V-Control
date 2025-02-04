using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Controls.Validations;

namespace VControl.Samples.Views;

public partial class VValidatingPickerView : ContentPageBase<VValidatingPickerViewModel>
{
    public static readonly BindableProperty PickerTitleProperty = BindableProperty.Create(
        nameof(PickerTitle),
        typeof(string),
        typeof(VValidatingPicker),
        string.Empty,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VValidatingPicker)
    );

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(IValidatableObject),
        typeof(VValidatingPicker),
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty IsPickerEnabledProperty = BindableProperty.Create(
        nameof(IsPickerEnabled),
        typeof(bool),
        typeof(VValidatingPicker),
        true,
        //propertyChanged: OnEntryTextPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty ValidateCommandProperty = BindableProperty.Create(
        nameof(ValidateCommand),
        typeof(ICommand),
        typeof(VValidatingPicker),
        null,
        defaultBindingMode: BindingMode.TwoWay
    );

    public string PickerTitle
    {
        get => (string)GetValue(PickerTitleProperty);
        set => SetValue(PickerTitleProperty, value);
    }

    public IList ItemsSource
    {
        get => (IList)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public IValidatableObject SelectedItem
    {
        get => (IValidatableObject)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public bool IsPickerEnabled
    {
        get => (bool)GetValue(IsPickerEnabledProperty);
        set => SetValue(IsPickerEnabledProperty, value);
    }

    public VValidatingPicker()
    {
        InitializeComponent();
    }

    public ICommand ValidateCommand
    {
        get => (ICommand)GetValue(ValidateCommandProperty);
        set => SetValue(ValidateCommandProperty, value);
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedItem?.Validate();
        this.ValidateCommand?.Execute(null);
    }
}
