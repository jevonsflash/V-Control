using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls.Compatibility;

namespace VControl.Samples.Views;

public partial class VEntryView : ContentPageBase<VEntryViewModel>
{

    public VEntry()
    {
        InitializeComponent();
        Loaded += VEntry_Loaded;

    }

    private void VEntry_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            this.MainContent.Content = (View)this.ContentSlot;
        }
        if (string.IsNullOrEmpty(EntryIconText))
        {
            HasIconText = false;
        }
        else
        {
            HasIconText = true;

        }
    }

    public static readonly BindableProperty HasIconTextProperty = BindableProperty.Create(nameof(HasIconText),
    typeof(bool), typeof(VEntry), true, BindingMode.TwoWay);


    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(
        nameof(EntryText),
        typeof(string),
        typeof(VEntry),
        string.Empty,
        //propertyChanged: OnEntryTextPropertyChanged, 
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryIconTextProperty = BindableProperty.Create(
       nameof(EntryIconText),
       typeof(string),
       typeof(VEntry),
       string.Empty,
       propertyChanged: OnEntryIconTextPropertyChanged,
       defaultBindingMode: BindingMode.OneWay);

    private static void OnEntryIconTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (string.IsNullOrEmpty(newValue as string))
        {
            (bindable as VEntry).HasIconText = false;
        }
        else
        {
            (bindable as VEntry).HasIconText = true;

        }
    }


    public static readonly BindableProperty EntryPlaceholderProperty = BindableProperty.Create(
      nameof(EntryPlaceholder),
      typeof(string),
      typeof(VEntry),
      "Enter content here.",
      //propertyChanged: OnEntryTextPropertyChanged, 
      defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty EntryKeyboardProperty = BindableProperty.Create(
       nameof(EntryKeyboard),
       typeof(Keyboard),
       typeof(VEntry),
       Keyboard.Default,
       //propertyChanged: OnEntryWidthPropertyChanged, 
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryMaxLengthProperty = BindableProperty.Create(
      nameof(EntryMaxLength),
      typeof(int),
      typeof(VEntry),
      int.MaxValue,
      defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryIsPasswordProperty = BindableProperty.Create(
        nameof(EntryIsPassword),
        typeof(bool),
        typeof(VEntry),
        false,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryIsReadOnlyProperty = BindableProperty.Create(
      nameof(EntryIsReadOnly),
      typeof(bool),
      typeof(VEntry),
      false,
      defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(VEntry), default(ICommand),
                propertyChanging: (bindable, oldvalue, newvalue) =>
                {
                    var vEntry = (VEntry)bindable;
                    var oldcommand = (ICommand)oldvalue;
                    if (oldcommand != null)
                        oldcommand.CanExecuteChanged -= vEntry.OnCommandCanExecuteChanged;
                }, propertyChanged: (bindable, oldvalue, newvalue) =>
                {
                    var vEntry = (VEntry)bindable;
                    var newcommand = (ICommand)newvalue;
                    if (newcommand != null)
                    {
                        vEntry.IsEnabled = newcommand.CanExecute(vEntry.CommandParameter);
                        newcommand.CanExecuteChanged += vEntry.OnCommandCanExecuteChanged;
                    }
                });

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(VEntry), default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vEntry = (VEntry)bindable;
            if (vEntry.Command != null)
            {
                vEntry.IsEnabled = vEntry.Command.CanExecute(newvalue);
            }
        });

    public IView ContentSlot
    {
        get;
        set;
    }

    public string EntryIconText
    {
        get => (string)GetValue(EntryIconTextProperty);
        set => SetValue(EntryIconTextProperty, value);
    }


    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    public string EntryPlaceholder
    {
        get => (string)GetValue(EntryPlaceholderProperty);
        set => SetValue(EntryPlaceholderProperty, value);
    }


    public Keyboard EntryKeyboard
    {
        get => (Keyboard)GetValue(EntryKeyboardProperty);
        set => SetValue(EntryKeyboardProperty, value);
    }

    public int EntryMaxLength
    {
        get => (int)GetValue(EntryMaxLengthProperty);
        set => SetValue(EntryMaxLengthProperty, value);
    }

    public bool EntryIsPassword
    {
        get => (bool)GetValue(EntryIsPasswordProperty);
        set => SetValue(EntryIsPasswordProperty, value);
    }
    public bool EntryIsReadOnly
    {
        get => (bool)GetValue(EntryIsReadOnlyProperty);
        set => SetValue(EntryIsReadOnlyProperty, value);
    }

    public bool HasIconText
    {
        get { return (bool)GetValue(HasIconTextProperty); }
        set { SetValue(HasIconTextProperty, value); }
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


    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Command?.Execute(CommandParameter);
#if IOS
        //focus is not obtained under ios, so manually focus
        (sender as Entry).Focus();
#endif
    }
}