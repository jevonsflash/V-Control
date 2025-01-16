
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace VControl.Controls;

public enum VTimeLineItemType
{
    Normal,
    Active,
    Success
}

public partial class VTimeLineItem : ContentView
{

    public event EventHandler Clicked;


    private void VTimeLineItem_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }

    }

    public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(VTimeLineItemType), typeof(VTimeLineItem), VTimeLineItemType.Normal,
    propertyChanged: TypeChanged);

    static void TypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var layout = (VTimeLineItem)bindable;
        layout.GoToState((VTimeLineItemType)newValue);
    }


    public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(VTimeLineItem), null);


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(VTimeLineItem), default(ICommand),
              propertyChanging: (bindable, oldvalue, newvalue) =>
              {
                  var vTimeLineItem = (VTimeLineItem)bindable;
                  var oldcommand = (ICommand)oldvalue;
                  if (oldcommand != null)
                      oldcommand.CanExecuteChanged -= vTimeLineItem.OnCommandCanExecuteChanged;
              }, propertyChanged: (bindable, oldvalue, newvalue) =>
              {
                  var vTimeLineItem = (VTimeLineItem)bindable;
                  var newcommand = (ICommand)newvalue;
                  if (newcommand != null)
                  {
                      vTimeLineItem.IsEnabled = newcommand.CanExecute(vTimeLineItem.CommandParameter);
                      newcommand.CanExecuteChanged += vTimeLineItem.OnCommandCanExecuteChanged;
                  }
              });

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(VTimeLineItem), default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vTimeLineItem = (VTimeLineItem)bindable;
            if (vTimeLineItem.Command != null)
            {
                vTimeLineItem.IsEnabled = vTimeLineItem.Command.CanExecute(newvalue);
            }
        });

    public static readonly BindableProperty IsLastOneProperty = BindableProperty.Create(nameof(IsLastOne),
    typeof(bool), typeof(VTimeLineItem), false, BindingMode.OneWay);


    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
     nameof(Title),
     typeof(string),
     typeof(VTimeLineItem),
     string.Empty);


    public static readonly BindableProperty DetailsProperty = BindableProperty.Create(
 nameof(Details),
 typeof(string),
 typeof(VTimeLineItem),
 string.Empty);


    public static readonly BindableProperty DateProperty = BindableProperty.Create(
     nameof(Date),
     typeof(string),
     typeof(VTimeLineItem),
     string.Empty);



    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
    nameof(IconText),
    typeof(string),
    typeof(VTimeLineItem),
    "\uF00C",
    defaultBindingMode: BindingMode.OneWay);


    public IView ContentSlot
    {
        get;
        set;
    }

    public bool IsLastOne
    {
        get { return (bool)GetValue(IsLastOneProperty); }
        set { SetValue(IsLastOneProperty, value); }
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Details
    {
        get => (string)GetValue(DetailsProperty);
        set => SetValue(DetailsProperty, value);
    }

    public string Date
    {
        get => (string)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }



    public Color TitleColor
    {
        get { return (Color)GetValue(TitleColorProperty); }
        set { SetValue(TitleColorProperty, value); }
    }

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }
    public string IconText
    {
        get => (string)GetValue(IconTextProperty);
        set => SetValue(IconTextProperty, value);
    }


    public VTimeLineItemType Type
    {
        get
        {
            return (VTimeLineItemType)GetValue(TypeProperty);
        }
        set
        {
            SetValue(TypeProperty, value);
        }
    }

    public VTimeLineItem()
    {
        InitializeComponent();
        Loaded += VTimeLineItem_Loaded;
        GoToState(Type);

    }


    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    public async void SelTapped(object sender, TappedEventArgs e)
    {
        IsLastOne = !IsLastOne;
        if (!IsEnabled)
        {
            return;
        }

        Command?.Execute(CommandParameter);
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public void GoToState(VTimeLineItemType timeLineItemType)
    {
        switch (timeLineItemType)
        {
            case VTimeLineItemType.Normal:
                VisualStateManager.GoToState(this, "Normal");

                break;
            case VTimeLineItemType.Active:
                VisualStateManager.GoToState(this, "Active");
                break;
            case VTimeLineItemType.Success:
                VisualStateManager.GoToState(this, "Success");
                break;
            default:
                break;
        }
    }

}