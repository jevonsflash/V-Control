using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using VControl.Controls;

namespace VControl.Controls;

public partial class VTagPicker : ContentView
{



    public VTagPicker()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(nameof(RemoveCommand), typeof(ICommand), typeof(VTagPicker));
    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(
        nameof(HasRemove),
        typeof(bool),
        typeof(VTagPicker), true,
          propertyChanged: OnHasRemovePropertyChanged
        );

    private static void OnHasRemovePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VTagPicker).NotifyChanged();

    }

    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
  nameof(DisplayPropertyName),
  typeof(string),
  typeof(VTagPicker),
  string.Empty,
         propertyChanged: onDisplayPropertyNamePropertyChanged

  );

    private static void onDisplayPropertyNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VTagPicker).NotifyChanged();
    }

    public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create(
            nameof(SelectedIndex),
            typeof(int),
            typeof(VTagPicker),
            0,
            BindingMode.TwoWay
        );


    public static readonly BindableProperty IsPickerEnabledProperty =
        BindableProperty.Create(
          nameof(IsPickerEnabled),
          typeof(bool),
          typeof(VTagPicker),
          true,
          propertyChanged: OnIsPickerEnabledChanged,
          defaultBindingMode: BindingMode.TwoWay);



    private static void OnIsPickerEnabledChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var vPicker = (VTagPicker)bindable;
        vPicker.SetEnable((bool)newValue);

    }

    private void SetEnable(bool isEnabled)
    {



    }

    public static readonly BindableProperty ItemsSourceProperty =
      BindableProperty.Create(
          nameof(ItemsSource),
          typeof(IList),
          typeof(VTagPicker),
          null,
          propertyChanged: OnItemsSourcePropertyChanged
      );


    private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VTagPicker).NotifyChanged();
        if (newValue is INotifyCollectionChanged)
        {
            (newValue as INotifyCollectionChanged).CollectionChanged += (bindable as VTagPicker).VTagPicker_CollectionChanged;
        }
    }

    private void VTagPicker_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        NotifyChanged();
    }

    public static readonly BindableProperty SelectedItemProperty =
       BindableProperty.Create(
           nameof(SelectedItem),
           typeof(object),
           typeof(VTagPicker),
           null,
           BindingMode.TwoWay,
           propertyChanged: onSelectedItemPropertyChanged
       );

    private static void onSelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bindable as VTagPicker).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VTagPicker).ItemsSource.IndexOf(newValue);
            (bindable as VTagPicker).SelectedIndex = (int)selectedIndex;
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
                    IsSelected = false,
                    HasRemove = this.HasRemove,
                    HasEdit = false,
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

    public bool HasRemove
    {
        get { return (bool)GetValue(HasRemoveProperty); }
        set { SetValue(HasRemoveProperty, value); }
    }

    public string DisplayPropertyName
    {
        get => (string)GetValue(DisplayPropertyNameProperty);
        set => SetValue(DisplayPropertyNameProperty, value);
    }


    public bool IsPickerEnabled
    {
        get => (bool)GetValue(IsPickerEnabledProperty);
        set => SetValue(IsPickerEnabledProperty, value);
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




    public DataTemplate ItemTemplate
    {
        get;
        set;
    }

   

    public ICommand RemoveCommand
    {
        get
        {
            return (ICommand)GetValue(RemoveCommandProperty);
        }
        set
        {
            SetValue(RemoveCommandProperty, value);
        }
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        var removeCommandParameter = ((sender as Button).BindingContext as VItemWrapper).Value;
        RemoveCommand?.Execute(removeCommandParameter);
    }

}