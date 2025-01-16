
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VControl.Controls;

namespace VControl.Controls;

public partial class VCheckableCollection : ContentView, INotifyPropertyChanged
{

    public event EventHandler<IList> SelectionChanged;
    bool _suppressSelectionChangeNotification;
    bool _suppressCollectionViewSelectionChangeNotification;
   
    public static readonly BindableProperty SearchKeywordsProperty = BindableProperty.Create(nameof(SearchKeywords), typeof(string), typeof(VSearchBar), default(string), BindingMode.TwoWay);


    public static readonly BindableProperty SelectionChangedCommandProperty =
    BindableProperty.Create(nameof(SelectionChangedCommand), typeof(ICommand), typeof(VCheckableCollection));

    public static readonly BindableProperty SelectionChangedCommandParameterProperty =
    BindableProperty.Create(nameof(SelectionChangedCommandParameter), typeof(object),
        typeof(VCheckableCollection));
    public static readonly BindableProperty HasCheckBoxProperty = BindableProperty.Create(nameof(HasCheckBox),
typeof(bool), typeof(VCheckableCollection), false);

    public static readonly BindableProperty HasEditProperty = BindableProperty.Create(nameof(HasEdit),
typeof(bool), typeof(VCheckableCollection), false);

    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(nameof(HasRemove),
typeof(bool), typeof(VCheckableCollection), false, propertyChanged: OnHasRemovePropertyChanged);

    private static void OnHasRemovePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VCheckableCollection).NotifyChanged();
    }

    public static readonly BindableProperty HasClearProperty = BindableProperty.Create(
        nameof(HasClear), typeof(bool), typeof(VCheckableCollection), true);

    public static readonly BindableProperty IsCollectionEnabledProperty = BindableProperty.Create(
      nameof(IsCollectionEnabled),
      typeof(bool),
      typeof(VCheckableCollection),
      true,
      defaultBindingMode: BindingMode.OneWay, propertyChanged: OnIsCollectionEnabledPropertyChanged);

    private static void OnIsCollectionEnabledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bool)newValue)
        {
            (bindable as VCheckableCollection).HasClear = false;
        };
    }


    public static readonly BindableProperty IsSingleSelectionProperty = BindableProperty.Create(
       nameof(IsSingleSelection),
       typeof(bool),
       typeof(VCheckableCollection),
       false,
       defaultBindingMode: BindingMode.OneWay, propertyChanged: OnIsSingleSelectionPropertyChanged);

    private static void OnIsSingleSelectionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bool)newValue)
        {
            (bindable as VCheckableCollection).MainCollectionView.SelectionMode = (Microsoft.Maui.Controls.SelectionMode)SelectionMode.Single;
        }
        else
        {
            (bindable as VCheckableCollection).MainCollectionView.SelectionMode = (Microsoft.Maui.Controls.SelectionMode)SelectionMode.Multiple;

        }
    }

    //¸ß¶È±ØÌî
    public static readonly BindableProperty FlHeightProperty = BindableProperty.Create(
        nameof(FlHeight),
        typeof(string),
        typeof(VCheckableCollection),
        "100",
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty FlDirectionProperty = BindableProperty.Create(
        nameof(FlDirection),
        typeof(FlexDirection),
        typeof(VCheckableCollection),
        FlexDirection.Row,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty FlWrapProperty = BindableProperty.Create(
        nameof(FlWrap),
        typeof(FlexWrap),
        typeof(VCheckableCollection),
        FlexWrap.Wrap,
        defaultBindingMode: BindingMode.OneWay);


    public static readonly BindableProperty ItemsSourceProperty =
         BindableProperty.Create(
             nameof(ItemsSource),
             typeof(IList),
             typeof(VCheckableCollection),
             null,
             propertyChanged: OnItemsSourcePropertyChanged

         );

    private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VCheckableCollection).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(
       nameof(SelectedItems),
       typeof(IList),
       typeof(VCheckableCollection),
       null,

       defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedItemsPropertyChanged);

    private static void OnSelectedItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue == default)
        {
            return;
        }
        if (newValue is INotifyCollectionChanged)
        {
            (newValue as INotifyCollectionChanged).CollectionChanged += (bindable as VCheckableCollection).VCheckableCollection_CollectionChanged;
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
            if (currentInternalItem != null && !this.MainCollectionView.SelectedItems.Contains(currentInternalItem))
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

    private void VCheckableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
      defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
  nameof(DisplayPropertyName),
  typeof(string),
  typeof(VCheckableCollection),
  string.Empty,
         propertyChanged: onDisplayPropertyNamePropertyChanged

  );

    private static void onDisplayPropertyNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VCheckableCollection).NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemProperty =
     BindableProperty.Create(
         nameof(SelectedItem),
         typeof(object),
         typeof(VCheckableCollection),
         null,
         BindingMode.TwoWay,
         propertyChanged: onSelectedItemPropertyChanged
     );

    public static readonly BindableProperty SelectedIndexProperty =
    BindableProperty.Create(
        nameof(SelectedIndex),
        typeof(int),
        typeof(VCheckableCollection),
        0,
        BindingMode.TwoWay
    );


    private static void onSelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
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

                var property = type.GetProperty((bindable as VCheckableCollection).DisplayPropertyName);

                if (property == null)
                {
                    throw new ArgumentException($"Property '{(bindable as VCheckableCollection).DisplayPropertyName}' not found on {type.FullName}");
                }
               (bindable as VCheckableCollection).SelectedValue = property.GetValue(newValue)?.ToString();
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
        get
        {
            return (IList)GetValue(ItemsSourceProperty);
        }
        set
        {
            SetValue(ItemsSourceProperty, value);
        }
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
        get
        {
            return GetValue(SelectedItemProperty);
        }
        set
        {
            SetValue(SelectedItemProperty, value);
        }
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
                    IsSelected = SelectedItems == null ? SelectedItem == c : SelectedItems.Contains(c),
                    HasRemove = this.HasRemove,
                    HasEdit = this.HasEdit,
                    IsEnabled = true
                };
                result.Add(current);
            }
            return result;
        }
    }

    public void NotifyChanged()
    {
        InternalItems = new List<VItemWrapper>(GetItemWrappers());
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
        get
        {
            return (int)GetValue(SelectedIndexProperty);
        }
        set
        {
            SetValue(SelectedIndexProperty, value);
        }
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
        get { return (bool)GetValue(HasEditProperty); }
        set { SetValue(HasEditProperty, value); }
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
            if (currentSelection != null)
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