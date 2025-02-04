using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Layouts;

namespace VControl.Controls;

public partial class VCheckableCollection : ContentView, INotifyPropertyChanged
{
    public event EventHandler<IList> SelectionChanged;
    bool _suppressSelectionChangeNotification;
    bool _suppressCollectionViewSelectionChangeNotification;

    public static readonly BindableProperty SearchKeywordsProperty = BindableProperty.Create(
        nameof(SearchKeywords),
        typeof(string),
        typeof(VCheckableCollection),
        default(string),
        BindingMode.TwoWay
    );

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommand),
            typeof(ICommand),
            typeof(VCheckableCollection)
        );

    public static readonly BindableProperty SelectionChangedCommandParameterProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommandParameter),
            typeof(object),
            typeof(VCheckableCollection)
        );


    public static readonly BindableProperty HasClearProperty = BindableProperty.Create(
        nameof(HasClear),
        typeof(bool),
        typeof(VCheckableCollection),
        true
    );


    public static readonly BindableProperty HasSearchBarProperty = BindableProperty.Create(
        nameof(HasSearchBar),
        typeof(bool),
        typeof(VCheckableCollection),
        true
    );


    public static readonly BindableProperty IsCollectionEnabledProperty = BindableProperty.Create(
        nameof(IsCollectionEnabled),
        typeof(bool),
        typeof(VCheckableCollection),
        true,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnIsCollectionEnabledPropertyChanged
    );

    private static void OnIsCollectionEnabledPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {



        if ((bool)newValue)
        {
            if ((bindable as VCheckableCollection).IsSingleSelection)
            {
                (bindable as VCheckableCollection).MainCollectionView.SelectionMode =
                    Microsoft.Maui.Controls.SelectionMode.Single;
            }
            else
            {
                (bindable as VCheckableCollection).MainCollectionView.SelectionMode =
                    Microsoft.Maui.Controls.SelectionMode.Multiple;
            }
        }
        else
        {
            (bindable as VCheckableCollection).MainCollectionView.SelectionMode = Microsoft.Maui.Controls.SelectionMode.None;
        }

        (bindable as VCheckableCollection).NotifyChanged();

    }

    public static readonly BindableProperty IsSingleSelectionProperty = BindableProperty.Create(
        nameof(IsSingleSelection),
        typeof(bool),
        typeof(VCheckableCollection),
        false,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnIsSingleSelectionPropertyChanged
    );

    private static void OnIsSingleSelectionPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VCheckableCollection).IsEnabled)
        {
            if ((bool)newValue)
            {
                (bindable as VCheckableCollection).MainCollectionView.SelectionMode =
                    Microsoft.Maui.Controls.SelectionMode.Single;
            }
            else
            {
                (bindable as VCheckableCollection).MainCollectionView.SelectionMode =
                    Microsoft.Maui.Controls.SelectionMode.Multiple;
            }
        }
        else
        {
            (bindable as VCheckableCollection).MainCollectionView.SelectionMode = Microsoft.Maui.Controls.SelectionMode.None;
        }
    }



    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VCheckableCollection),
        null,
        propertyChanged: OnItemsSourcePropertyChanged
    );

    private static void OnItemsSourcePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VCheckableCollection).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(
        nameof(SelectedItems),
        typeof(IList),
        typeof(VCheckableCollection),
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
                bindable as VCheckableCollection
            ).VCheckableCollection_CollectionChanged;
            if (oldValue == null)
            {
                (bindable as VCheckableCollection).UpdateItemSelection((IList)newValue);
            }
        }
        else
        {
            (bindable as VCheckableCollection).UpdateItemSelection((IList)newValue);
        }
    }

    public void UpdateItemSelection(IList selectedItems)
    {
        if (_suppressSelectionChangeNotification)
        {
            return;
        }
        _suppressCollectionViewSelectionChangeNotification = true;
        foreach (var item in selectedItems)
        {
            var currentInternalItem = this.InternalItems.FirstOrDefault(c => c.Value == item);
            if (
                currentInternalItem != null
                && !this.MainCollectionView.SelectedItems.Contains(currentInternalItem)
            )
            {
                var currentIndex = this.InternalItems.IndexOf(currentInternalItem);
                if (currentIndex != -1)
                {
                    this.InternalItems[currentIndex].IsSelected = true;
                    this.MainCollectionView.SelectedItems.Add(currentInternalItem);
                }
            }
        }
        _suppressCollectionViewSelectionChangeNotification = false;
    }

    private void VCheckableCollection_CollectionChanged(
        object sender,
        NotifyCollectionChangedEventArgs e
    )
    {
        if (_suppressSelectionChangeNotification)
        {
            return;
        }
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
        typeof(VCheckableCollection),
        "",
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
        nameof(DisplayPropertyName),
        typeof(string),
        typeof(VCheckableCollection),
        string.Empty,
        propertyChanged: OnDisplayPropertyNamePropertyChanged
    );

    private static void OnDisplayPropertyNamePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VCheckableCollection).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(VCheckableCollection),
        null,
        BindingMode.TwoWay,
        propertyChanged: OnSelectedItemPropertyChanged
    );

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VCheckableCollection),
        0,
        BindingMode.TwoWay
    );

    private static void OnSelectedItemPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VCheckableCollection).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VCheckableCollection).ItemsSource.IndexOf(newValue);
            (bindable as VCheckableCollection).SelectedIndex = (int)selectedIndex;

            if (string.IsNullOrEmpty((bindable as VCheckableCollection).DisplayPropertyName))
            {
                (bindable as VCheckableCollection).SelectedValue = newValue.ToString();
            }
            else
            {
                Type type = newValue.GetType();

                var property = type.GetProperty(
                    (bindable as VCheckableCollection).DisplayPropertyName
                );

                if (property == null)
                {
                    throw new ArgumentException(
                        $"Property '{(bindable as VCheckableCollection).DisplayPropertyName}' not found on {type.FullName}"
                    );
                }
                (bindable as VCheckableCollection).SelectedValue = property
                    .GetValue(newValue)
                    ?.ToString();
            }
        }

        (bindable as VCheckableCollection).OnSelectedItemProperty(oldValue, newValue);
    }

    public string SearchKeywords
    {
        get { return (string)GetValue(SearchKeywordsProperty); }
        set { SetValue(SearchKeywordsProperty, value); }
    }
    public bool HasClear
    {
        get { return (bool)GetValue(HasClearProperty); }
        set { SetValue(HasClearProperty, value); }
    }

    public bool HasSearchBar
    {
        get { return (bool)GetValue(HasSearchBarProperty); }
        set { SetValue(HasSearchBarProperty, value); }
    }

    public bool IsSingleSelection
    {
        get => (bool)GetValue(IsSingleSelectionProperty);
        set => SetValue(IsSingleSelectionProperty, value);
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

    public bool IsCollectionEnabled
    {
        get => (bool)GetValue(IsCollectionEnabledProperty);
        set => SetValue(IsCollectionEnabledProperty, value);
    }
    public object SelectedItem
    {
        get { return GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }

    private IList<VItemWrapper> _internalItems;

    public IList<VItemWrapper> InternalItems
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
                    IsSelected = SelectedItems == null ? false : SelectedItems.Contains(c),
                };
                result.Add(current);
            }
            return result;
        }
    }

    public void NotifyChanged()
    {
        InternalItems = new List<VItemWrapper>(GetItemWrappers());
        _suppressCollectionViewSelectionChangeNotification = true;

        MainCollectionView.SelectedItems.Clear();
        foreach (var item in InternalItems)
        {
            if (item.IsSelected)
            {

                MainCollectionView.SelectedItems.Add(item);
            }

        }
        _suppressCollectionViewSelectionChangeNotification = false;

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
        this.MainCollectionView.SelectedItems.Clear();
    }

    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }




    public VCheckableCollection()
    {
        InitializeComponent();
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressCollectionViewSelectionChangeNotification)
        {
            return;
        }
        if (ItemsSource != null)
        {
            var currentSelection = e.CurrentSelection;
            if (currentSelection != null && this.SelectedItems != null)
            {
                _suppressSelectionChangeNotification = true;

                var currentUnSelection = InternalItems.Except(currentSelection);

                foreach (var currentObject in currentSelection)
                {
                    var value = (currentObject as VItemWrapper).Value;
                    var currentIndex = InternalItems.IndexOf(currentObject as VItemWrapper);
                    if (currentIndex != -1)
                    {
                        InternalItems[currentIndex].IsSelected = true;

                        if (!this.SelectedItems.Contains(value))
                        {
                            this.SelectedItems.Add(value);
                        }
                    }
                }

                foreach (var currentObject in currentUnSelection)
                {
                    var value = (currentObject as VItemWrapper).Value;
                    var currentIndex = InternalItems.IndexOf(currentObject as VItemWrapper);
                    if (currentIndex != -1)
                    {
                        InternalItems[currentIndex].IsSelected = false;
                        this.SelectedItems.Remove(value);
                    }
                }

                _suppressSelectionChangeNotification = false;

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
