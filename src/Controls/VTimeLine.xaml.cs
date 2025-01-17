using System.Collections;

namespace VControl.Controls;

public partial class VTimeLine : ContentView
{
    public VTimeLine()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VTimeLine),
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
        typeof(VTimeLine),
        null,
        propertyChanged: OnItemsSourcePropertyChanged
    );

    private static void OnItemsSourcePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VTimeLine).MainStackLayoutContextChanged();
    }

    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public DataTemplate ItemTemplate { get; set; }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(VTimeLine),
        null,
        BindingMode.TwoWay,
        propertyChanged: onSelectedItemPropertyChanged
    );

    private static void onSelectedItemPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VTimeLine).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VTimeLine).ItemsSource.IndexOf(newValue);
            (bindable as VTimeLine).SelectedIndex = (int)selectedIndex;
        }
    }

    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }

    private void MainStackLayoutContextChanged()
    {
        var sender = this.FindByName("MainStackLayout") as Layout;
        var lastOne = (sender as Layout).Children.LastOrDefault();
        if (lastOne != null && lastOne is VTimeLineItem)
        {
            (lastOne as VTimeLineItem).IsLastOne = true;
        }
    }
}
