using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Layouts;

namespace VControl.Controls;

public partial class VCollection : ContentView, INotifyPropertyChanged
{
    public event EventHandler<IList> SelectionChanged;

    public static readonly BindableProperty SearchKeywordsProperty = BindableProperty.Create(
        nameof(SearchKeywords),
        typeof(string),
        typeof(VCollection),
        default(string),
        BindingMode.TwoWay
    );

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommand),
            typeof(ICommand),
            typeof(VCollection)
        );

    public static readonly BindableProperty SelectionChangedCommandParameterProperty =
        BindableProperty.Create(
            nameof(SelectionChangedCommandParameter),
            typeof(object),
            typeof(VCollection)
        );
    public static readonly BindableProperty HasCheckBoxProperty = BindableProperty.Create(
        nameof(HasCheckBox),
        typeof(bool),
        typeof(VCollection),
        false
    );

    public static readonly BindableProperty HasEditProperty = BindableProperty.Create(
        nameof(HasEdit),
        typeof(bool),
        typeof(VCollection),
        false
    );

    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(
        nameof(HasRemove),
        typeof(bool),
        typeof(VCollection),
        false
    );

  

    public static readonly BindableProperty HasSearchBarProperty = BindableProperty.Create(
    nameof(HasSearchBar),
    typeof(bool),
    typeof(VCollection),
    true
);

    public static readonly BindableProperty IsCollectionEnabledProperty = BindableProperty.Create(
        nameof(IsCollectionEnabled),
        typeof(bool),
        typeof(VCollection),
        true,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnNotifyPropertyChanged

    );

   

    public static readonly BindableProperty IsSingleSelectionProperty = BindableProperty.Create(
        nameof(IsSingleSelection),
        typeof(bool),
        typeof(VCollection),
        false,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VCollection),
        null,
        propertyChanged: OnNotifyPropertyChanged
    );

  

    public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(
        nameof(SelectedItems),
        typeof(IList),
        typeof(VCollection),
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
                bindable as VCollection
            ).VCollection_CollectionChanged;
            if (oldValue == null)
            {
                (bindable as VCollection).UpdateItemSelection((IList)newValue);
            }
        }
        else
        {
            (bindable as VCollection).UpdateItemSelection((IList)newValue);
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

    private void VCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
        typeof(VCollection),
        "",
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
        nameof(DisplayPropertyName),
        typeof(string),
        typeof(VCollection),
        string.Empty,
        propertyChanged: OnNotifyPropertyChanged
    );

   

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(VCollection),
        null,
        BindingMode.TwoWay,
        propertyChanged: OnSelectedItemPropertyChanged
    );

    public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
    nameof(EditCommand),
    typeof(ICommand),
    typeof(VCollection)
);
    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(
        nameof(RemoveCommand),
        typeof(ICommand),
        typeof(VCollection)
    );

    public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VCollection),
        0,
        BindingMode.TwoWay
    );

    private static void OnSelectedItemPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VCollection).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VCollection).ItemsSource.IndexOf(newValue);
            (bindable as VCollection).SelectedIndex = (int)selectedIndex;

            if (string.IsNullOrEmpty((bindable as VCollection).DisplayPropertyName))
            {
                (bindable as VCollection).SelectedValue = newValue.ToString();
            }
            else
            {
                Type type = newValue.GetType();

                var property = type.GetProperty((bindable as VCollection).DisplayPropertyName);

                if (property == null)
                {
                    throw new ArgumentException(
                        $"Property '{(bindable as VCollection).DisplayPropertyName}' not found on {type.FullName}"
                    );
                }
                (bindable as VCollection).SelectedValue = property.GetValue(newValue)?.ToString();
            }
        }

        (bindable as VCollection).OnSelectedItemProperty(oldValue, newValue);
    }

    private static void OnNotifyPropertyChanged(
      BindableObject bindable,
      object oldValue,
      object newValue
  )
    {
        (bindable as VCollection).NotifyChanged();
    }




    public string SearchKeywords
    {
        get { return (string)GetValue(SearchKeywordsProperty); }
        set { SetValue(SearchKeywordsProperty, value); }
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

    public ICommand EditCommand
    {
        get { return (ICommand)GetValue(EditCommandProperty); }
        set { SetValue(EditCommandProperty, value); }
    }

    public ICommand RemoveCommand
    {
        get { return (ICommand)GetValue(RemoveCommandProperty); }
        set { SetValue(RemoveCommandProperty, value); }
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
                    HasRemove = this.HasRemove,
                    HasEdit = this.HasEdit,
                    IsEnabled = this.IsCollectionEnabled,
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

    public bool HasCheckBox
    {
        get { return (bool)GetValue(HasCheckBoxProperty); }
        set { SetValue(HasCheckBoxProperty, value); }
    }

    public bool HasEdit
    {
        get { return (bool)GetValue(HasEditProperty); }
        set { SetValue(HasEditProperty, value); }
    }

    public bool HasRemove
    {
        get { return (bool)GetValue(HasRemoveProperty); }
        set { SetValue(HasRemoveProperty, value); }
    }

    public VCollection()
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

   
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        var currentItem = (sender as BindableObject).BindingContext;

        InternalItems.Remove(currentItem as VItemWrapper);

        this.RemoveCommand?.Execute((currentItem as VItemWrapper).Value);
    }

    private void VCollectionItem_EditButtonClicked(object sender, EventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        var currentItem = (sender as BindableObject).BindingContext;
        this.EditCommand?.Execute((currentItem as VItemWrapper).Value);

    }
}
