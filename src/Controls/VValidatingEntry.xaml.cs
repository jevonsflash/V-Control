using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Controls.Validations;

namespace VControl.Controls;

public partial class VValidatingEntry : ContentView
{

    public static readonly BindableProperty HasIconTextProperty = BindableProperty.Create(nameof(HasIconText),
typeof(bool), typeof(VValidatingEntry), true, BindingMode.TwoWay);

    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(
        nameof(EntryText), 
        typeof(IValidatableObject), 
        typeof(VValidatingEntry),
        default,
        //propertyChanged: OnEntryTextPropertyChanged, 
        defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty EntryIconTextProperty = BindableProperty.Create(
     nameof(EntryIconText),
     typeof(string),
     typeof(VValidatingEntry),
     "",
     propertyChanged: OnEntryIconTextPropertyChanged,
     defaultBindingMode: BindingMode.OneWay);

    private static void OnEntryIconTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (string.IsNullOrEmpty(newValue as string))
        {
            (bindable as VValidatingEntry).HasIconText = false;
        }
        else
        {
            (bindable as VValidatingEntry).HasIconText = true;

        }
    }

    public static readonly BindableProperty EntryPlaceholderProperty = BindableProperty.Create(
       nameof(EntryPlaceholder),
       typeof(string),
       typeof(VValidatingEntry),
       "Enter content here.",
       //propertyChanged: OnEntryTextPropertyChanged, 
       defaultBindingMode: BindingMode.OneWay);

  

    public static readonly BindableProperty EntryKeyboardProperty = BindableProperty.Create(
       nameof(EntryKeyboard),
       typeof(Keyboard),
       typeof(VValidatingEntry),
       Keyboard.Default,
       //propertyChanged: OnEntryWidthPropertyChanged, 
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryMaxLengthProperty = BindableProperty.Create(
      nameof(EntryMaxLength),
      typeof(int?),
      typeof(VValidatingEntry),
      null,
      defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty EntryIsPasswordProperty = BindableProperty.Create(
        nameof(EntryIsPassword),
        typeof(bool),
        typeof(VValidatingEntry),
        false,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty ValidateCommandProperty = BindableProperty.Create(
     nameof(ValidateCommand),
     typeof(ICommand),
     typeof(VValidatingEntry),
     null,
     defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(VValidatingEntry), default(ICommand),
               propertyChanging: (bindable, oldvalue, newvalue) =>
               {
                   var vEntry = (VValidatingEntry)bindable;
                   var oldcommand = (ICommand)oldvalue;
                   if (oldcommand != null)
                       oldcommand.CanExecuteChanged -= vEntry.OnCommandCanExecuteChanged;
               }, propertyChanged: (bindable, oldvalue, newvalue) =>
               {
                   var vEntry = (VValidatingEntry)bindable;
                   var newcommand = (ICommand)newvalue;
                   if (newcommand != null)
                   {
                       vEntry.IsEnabled = newcommand.CanExecute(vEntry.CommandParameter);
                       newcommand.CanExecuteChanged += vEntry.OnCommandCanExecuteChanged;
                   }
               });

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(VValidatingEntry), default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vEntry = (VValidatingEntry)bindable;
            if (vEntry.Command != null)
            {
                vEntry.IsEnabled = vEntry.Command.CanExecute(newvalue);
            }
        });


    public string EntryIconText
    {
        get => (string)GetValue(EntryIconTextProperty);
        set => SetValue(EntryIconTextProperty, value);
    }
    public IValidatableObject EntryText
    {
        get => (IValidatableObject)GetValue(EntryTextProperty);
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

    public int? EntryMaxLength
    {
        get => (int?)GetValue(EntryMaxLengthProperty);
        set => SetValue(EntryMaxLengthProperty, value);
    }

    public bool EntryIsPassword
    {
        get => (bool)GetValue(EntryIsPasswordProperty);
        set => SetValue(EntryIsPasswordProperty, value);
    }

    public bool HasIconText
    {
        get { return (bool)GetValue(HasIconTextProperty); }
        set { SetValue(HasIconTextProperty, value); }
    }
    public VValidatingEntry()
	{
		InitializeComponent();
    }

    public ICommand ValidateCommand
    {
        get => (ICommand)GetValue(ValidateCommandProperty);
        set => SetValue(ValidateCommandProperty, value);
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

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.EntryText?.Validate();
        this.ValidateCommand?.Execute(null);
    }
}