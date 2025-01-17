using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Layouts;

namespace VControl.Controls;

public partial class VCheckBoxGroup : ContentView, INotifyPropertyChanged
{
    public event EventHandler<IList> SelectionChanged;

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommand),
            typeof(ICommand),
            typeof(VCheckBoxGroup)
        );

    public static readonly BindableProperty SelectionChangedCommandParameterProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommandParameter),
            typeof(object),
            typeof(VCheckBoxGroup)
        );

    public static readonly BindableProperty HasClearProperty = BindableProperty.Create(
        nameof(HasClear),
        typeof(bool),
        typeof(VCheckBoxGroup),
        true
    );

    public static readonly BindableProperty IsCheckBoxGroupEnabledProperty =
        BindableProperty.Create(
            nameof(IsCheckBoxGroupEnabled),
            typeof(bool),
            typeof(VCheckBoxGroup),
            true,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: OnIsCheckBoxGroupEnabledPropertyChanged
        );

    private static void OnIsCheckBoxGroupEnabledPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bool)newValue)
        {
            (bindable as VCheckBoxGroup).HasClear = false;
        }
        ;
    }

    public static readonly BindableProperty IsSingleSelectionProperty = BindableProperty.Create(
        nameof(IsSingleSelection),
        typeof(bool),
        typeof(VCheckBoxGroup),
        false,
        defaultBindingMode: BindingMode.OneWay
    );

    //�߶ȱ���
    public static readonly BindableProperty FlHeightProperty = BindableProperty.Create(
        nameof(FlHeight),
        typeof(string),
        typeof(VCheckBoxGroup),
        "100",
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty FlDirectionProperty = BindableProperty.Create(
        nameof(FlDirection),
        typeof(FlexDirection),
        typeof(VCheckBoxGroup),
        FlexDirection.Row,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty FlWrapProperty = BindableProperty.Create(
        nameof(FlWrap),
        typeof(FlexWrap),
        typeof(VCheckBoxGroup),
        FlexWrap.Wrap,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VCheckBoxGroup),
        null,
        propertyChanged: OnItemsSourcePropertyChanged
    );

    private static void OnItemsSourcePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VCheckBoxGroup).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(
        nameof(SelectedItems),
        typeof(IList),
        typeof(VCheckBoxGroup),
        null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: OnSelectedItemsPropertyChanged
    );

    private static void OnSelectedItemsPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if (newValue == default)
        {
            return;
        }
        if (newValue is INotifyCollectionChanged)
        {
            (newValue as INotifyCollectionChanged).CollectionChanged += (
                bindable as VCheckBoxGroup
            ).VCheckBoxGroup_CollectionChanged;
        }
        else
        {
            (bindable as VCheckBoxGroup).UpdateItemSelection((IList)newValue);
        }
    }

    public void UpdateItemSelection(IList selectedItems)
    {
        foreach (var item in InternalItems)
        {
            item.IsSelected = false;
        }

        foreach (var item in selectedItems)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                if (InternalItems[i].Value == item)
                {
                    this.InternalItems[i].IsSelected = true;
                }
            }
        }
    }

    private void VCheckBoxGroup_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (var item in e.NewItems)
            {
                for (int i = 0; i < InternalItems.Count; i++)
                {
                    if (InternalItems[i].Value == item && !this.InternalItems[i].IsSelected)
                    {
                        this.InternalItems[i].IsSelected = true;
                    }
                }
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach (var item in e.OldItems)
            {
                for (int i = 0; i < InternalItems.Count; i++)
                {
                    if (InternalItems[i].Value == item && this.InternalItems[i].IsSelected)
                    {
                        this.InternalItems[i].IsSelected = false;
                    }
                }
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Reset)
        {
            for (int i = 0; i < InternalItems.Count; i++)
            {
                this.InternalItems[i].IsSelected = false;
            }
        }
    }

    public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create(
        nameof(SelectedValue),
        typeof(string),
        typeof(VCheckBoxGroup),
        "",
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
        nameof(DisplayPropertyName),
        typeof(string),
        typeof(VCheckBoxGroup),
        string.Empty,
        propertyChanged: onDisplayPropertyNamePropertyChanged
    );

    private static void onDisplayPropertyNamePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VCheckBoxGroup).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(VCheckBoxGroup),
        null,
        BindingMode.TwoWay,
        propertyChanged: onSelectedItemPropertyChanged
    );

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VCheckBoxGroup),
        0,
        BindingMode.TwoWay
    );

    private static void onSelectedItemPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VCheckBoxGroup).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VCheckBoxGroup).ItemsSource.IndexOf(newValue);
            (bindable as VCheckBoxGroup).SelectedIndex = (int)selectedIndex;

            if (string.IsNullOrEmpty((bindable as VCheckBoxGroup).DisplayPropertyName))
            {
                (bindable as VCheckBoxGroup).SelectedValue = newValue.ToString();
            }
            else
            {
                Type type = newValue.GetType();

                var property = type.GetProperty((bindable as VCheckBoxGroup).DisplayPropertyName);

                if (property == null)
                {
                    throw new ArgumentException(
                        $"Property '{(bindable as VCheckBoxGroup).DisplayPropertyName}' not found on {type.FullName}"
                    );
                }
                (bindable as VCheckBoxGroup).SelectedValue = property
                    .GetValue(newValue)
                    ?.ToString();
            }
        }

        (bindable as VCheckBoxGroup).OnSelectedItemProperty(oldValue, newValue);
    }

    public bool HasClear
    {
        get { return (bool)GetValue(HasClearProperty); }
        set { SetValue(HasClearProperty, value); }
    }

    public bool IsSingleSelection
    {
        get => (bool)GetValue(IsSingleSelectionProperty);
        set => SetValue(IsSingleSelectionProperty, value);
    }

    public string FlHeight
    {
        get => (string)GetValue(FlHeightProperty);
        set => SetValue(FlHeightProperty, value);
    }

    public FlexDirection FlDirection
    {
        get => (FlexDirection)GetValue(FlDirectionProperty);
        set => SetValue(FlDirectionProperty, value);
    }

    public FlexWrap FlWrap
    {
        get => (FlexWrap)GetValue(FlWrapProperty);
        set => SetValue(FlWrapProperty, value);
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

    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public IList SelectedItems
    {
        get => (IList)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    public string SelectedValue
    {
        get => (string)GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
    }

    public string DisplayPropertyName
    {
        get => (string)GetValue(DisplayPropertyNameProperty);
        set => SetValue(DisplayPropertyNameProperty, value);
    }

    public bool IsCheckBoxGroupEnabled
    {
        get => (bool)GetValue(IsCheckBoxGroupEnabledProperty);
        set => SetValue(IsCheckBoxGroupEnabledProperty, value);
    }
    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }

    private ObservableCollection<VItemWrapper> _internalItems;

    public ObservableCollection<VItemWrapper> InternalItems
    {
        get { return _internalItems; }
        set
        {
            _internalItems = value;
            OnPropertyChanged();
        }
    }

    private IList<VItemWrapper> GetItemWrappers()
    {
        var result = new List<VItemWrapper>();
        if (this.ItemsSource == null)
        {
            return result;
        }
        else
        {
            foreach (var c in ItemsSource)
            {
                var current = new VItemWrapper()
                {
                    Value = c,
                    DisplayPropertyName = this.DisplayPropertyName,
                    Index = ItemsSource.IndexOf(c),
                    IsSelected =
                        SelectedItems == null ? SelectedItem == c : SelectedItems.Contains(c),
                    HasRemove = false,
                    HasEdit = false,
                    IsEnabled = true,
                };
                result.Add(current);
            }
            return result;
        }
    }

    public void NotifyChanged()
    {
        InternalItems = new ObservableCollection<VItemWrapper>(GetItemWrappers());
    }

    public void OnSelectedItemProperty(object oldValue, object newValue)
    {
        if (this.IsSingleSelection)
        {
            for (int i = 0; i < this.InternalItems.Count; i++)
            {
                var currentItem = this.InternalItems[i].Value;

                if (newValue == currentItem)
                {
                    this.InternalItems[i].IsSelected = true;
                }
                else
                {
                    if (InternalItems[i].IsSelected)
                    {
                        this.InternalItems[i].IsSelected = false;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < this.InternalItems.Count; i++)
            {
                var currentItem = this.InternalItems[i].Value;

                if (newValue == currentItem)
                {
                    this.InternalItems[i].IsSelected = true;
                }
            }
        }
    }

    public void ClearSelection()
    {
        for (int i = 0; i < this.InternalItems.Count; i++)
        {
            if (InternalItems[i].IsSelected)
            {
                this.InternalItems[i].IsSelected = false;
            }
        }
        SelectedItem = default;
    }

    public void SelectAll()
    {
        for (int i = 0; i < this.InternalItems.Count; i++)
        {
            if (!InternalItems[i].IsSelected)
            {
                this.InternalItems[i].IsSelected = true;
            }
        }
    }

    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }

    public VCheckBoxGroup()
    {
        InitializeComponent();
    }

    private void VCheckBoxButton_Clicked(object sender, EventArgs e)
    {
        if (ItemsSource != null)
        {
            var currentObject = (sender as BindableObject).BindingContext;
            if (currentObject != null && currentObject is VItemWrapper)
            {
                var value = (currentObject as VItemWrapper).Value;
                if ((currentObject as VItemWrapper).IsSelected)
                {
                    if (this.IsSingleSelection)
                    {
                        this.SelectedItems?.Clear();
                    }
                    this.SelectedItems?.Add(value);
                    this.SelectedItem = value;
                }
                else
                {
                    this.SelectedItems?.Remove(value);
                    this.SelectedItem = null;
                }

                this.SelectionChanged?.Invoke(this, this.SelectedItems);

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
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        this.ClearSelection();
        this.SelectedItems?.Clear();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        var currentItem = (sender as BindableObject).BindingContext;

        InternalItems.Remove(currentItem as VItemWrapper);
    }
}
