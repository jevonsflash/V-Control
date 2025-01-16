using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace VControl.Controls;

public partial class VPicker : ContentView
{
    public static readonly BindableProperty PickerTitleProperty = BindableProperty.Create(
      nameof(PickerTitle),
      typeof(string),
      typeof(VPicker),
      string.Empty,
      defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty DisplayPropertyNameProperty = BindableProperty.Create(
  nameof(DisplayPropertyName),
  typeof(string),
  typeof(VPicker),
  string.Empty,
         propertyChanged: onDisplayPropertyNamePropertyChanged

  );

    private static void onDisplayPropertyNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VPicker).NotifyChanged();
    }


    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList),
            typeof(VPicker),
            null,
            propertyChanged: OnItemsSourcePropertyChanged

        );

    private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VPicker).NotifyChanged();
    }

    public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create(
     nameof(SelectedValue),
     typeof(string),
     typeof(VPicker),
     "",
     defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty SelectedIndexProperty =
  BindableProperty.Create(
      nameof(SelectedIndex),
      typeof(int),
      typeof(VPicker),
      0,
      BindingMode.TwoWay
  );

    public static readonly BindableProperty SelectedItemProperty =
     BindableProperty.Create(
         nameof(SelectedItem),
         typeof(object),
         typeof(VPicker),
         null,
         BindingMode.TwoWay,
         propertyChanged: onSelectedItemPropertyChanged
     );




    private static void onSelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bindable as VPicker).ItemsSource != null && newValue != null)
        {
            var selectedIndex = (bindable as VPicker).ItemsSource.IndexOf(newValue);
            (bindable as VPicker).SelectedIndex = (int)selectedIndex;
            var currentInternalSelectedItem = (bindable as VPicker).InternalItems.FirstOrDefault(c => c.Value == newValue);
            if (currentInternalSelectedItem != (bindable as VPicker).InternalSelectedItem)
            {
                (bindable as VPicker).InternalSelectedItem = currentInternalSelectedItem;

            }

            if (string.IsNullOrEmpty((bindable as VPicker).DisplayPropertyName))
            {
                (bindable as VPicker).SelectedValue = newValue.ToString();
            }
            else
            {
                Type type = newValue.GetType();

                var property = type.GetProperty((bindable as VPicker).DisplayPropertyName);

                if (property == null)
                {
                    throw new ArgumentException($"Property '{(bindable as VPicker).DisplayPropertyName}' not found on {type.FullName}");
                }
               (bindable as VPicker).SelectedValue = property.GetValue(newValue)?.ToString();
            }
        }
    }


    public static readonly BindableProperty IsPickerEnabledProperty = BindableProperty.Create(
      nameof(IsPickerEnabled),
      typeof(bool),
      typeof(VPicker),
      true,
      //propertyChanged: OnEntryTextPropertyChanged, 
      defaultBindingMode: BindingMode.TwoWay);

    public string PickerTitle
    {
        get => (string)GetValue(PickerTitleProperty);
        set => SetValue(PickerTitleProperty, value);
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
    public object SelectedItem
    {
        get => (object)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public bool IsPickerEnabled
    {
        get => (bool)GetValue(IsPickerEnabledProperty);
        set => SetValue(IsPickerEnabledProperty, value);
    }

    public string DisplayPropertyName
    {
        get => (string)GetValue(DisplayPropertyNameProperty);
        set => SetValue(DisplayPropertyNameProperty, value);
    }

    public string SelectedValue
    {
        get => (string)GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
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


    public VPicker()
    {
        InitializeComponent();
    }

    public void NotifyChanged()
    {
        InternalItems = new List<VPickerItemWrapper>(GetItemWrappers());
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(this.InternalSelectedItem))
        {
            if (this.InternalSelectedItem == null)
            {
                this.SelectedItem = null;
            }
            else
            {
                this.SelectedItem = this.InternalSelectedItem.Value;
            }
        }
    }


    private IList<VPickerItemWrapper> _internalItems;

    public IList<VPickerItemWrapper> InternalItems
    {
        get { return _internalItems; }
        set
        {
            _internalItems = value;
            OnPropertyChanged();
        }
    }

    private VPickerItemWrapper _internalSelectedItem;

    public VPickerItemWrapper InternalSelectedItem
    {
        get { return _internalSelectedItem; }
        set
        {
            _internalSelectedItem = value;
            OnPropertyChanged();
        }
    }


    private IList<VPickerItemWrapper> GetItemWrappers()
    {
        var result = new List<VPickerItemWrapper>();
        if (this.ItemsSource == null)
        {
            return result;
        }
        else
        {
            foreach (var c in ItemsSource)
            {
                var current = new VPickerItemWrapper()
                {
                    Value = c,
                    DisplayPropertyName = this.DisplayPropertyName,
                };
                result.Add(current);
            }
            return result;
        }
    }





}