using System.Collections;

namespace VControl.Controls;

public partial class VRadioButton : ContentView
{
    public VRadioButton()
    {
        InitializeComponent();
        RadioButtonGroup.SetGroupName(_stack, Guid.NewGuid().ToString());
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VRadioButton),
        0,
        BindingMode.TwoWay
    );

    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VRadioButton),
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
        typeof(VRadioButton),
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
        if ((bindable as VRadioButton).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VRadioButton).ItemsSource.IndexOf(newValue);
            (bindable as VRadioButton).SelectedIndex = (int)selectedIndex;
        }
    }

    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
}
