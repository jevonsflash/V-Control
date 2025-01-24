using System.Collections;

namespace VControl.Controls;

public partial class VRadioButtonGroup : ContentView
{
    public VRadioButtonGroup()
    {
        InitializeComponent();
        RadioButtonGroup.SetGroupName(_stack, Guid.NewGuid().ToString());
        this.UpdateRadioButtonGroupDirection();
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VRadioButtonGroup),
        0,
        BindingMode.TwoWay
    );

    public static readonly BindableProperty RadioButtonGroupDirectionProperty = BindableProperty.Create(
    nameof(RadioButtonGroupDirection),
    typeof(RadioButtonGroupDirection),
    typeof(VRadioButtonGroup),
    RadioButtonGroupDirection.Horizontal,
    propertyChanged: OnRadioButtonGroupDirectionChanged
);

    static void OnRadioButtonGroupDirectionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VRadioButtonGroup)?.UpdateRadioButtonGroupDirection();
    }


    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VRadioButtonGroup),
        null
    );

    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(VRadioButtonGroup),
        null,
        BindingMode.TwoWay,
        propertyChanged: OnSelectedItemPropertyChanged
    );

    private static void OnSelectedItemPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VRadioButtonGroup).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VRadioButtonGroup).ItemsSource.IndexOf(newValue);
            (bindable as VRadioButtonGroup).SelectedIndex = (int)selectedIndex;
        }
    }

    public RadioButtonGroupDirection RadioButtonGroupDirection
    {
        get => (RadioButtonGroupDirection)GetValue(RadioButtonGroupDirectionProperty);
        set => SetValue(RadioButtonGroupDirectionProperty, value);
    }


    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }


    private void UpdateRadioButtonGroupDirection()
    {
        if (RadioButtonGroupDirection == RadioButtonGroupDirection.Horizontal)
        {
            _stack.Orientation = StackOrientation.Horizontal;
        }
        else if (RadioButtonGroupDirection == RadioButtonGroupDirection.Vertical)
        {
            _stack.Orientation = StackOrientation.Vertical;

        }
    }
}
