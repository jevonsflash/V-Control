using System.Windows.Input;

namespace VControl.Controls;

public partial class VCheckBoxButton : ContentView
{
    public event EventHandler Clicked;
    public event EventHandler RemoveButtonClicked;

    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(
        nameof(HasRemove),
        typeof(bool),
        typeof(VCheckBoxButton),
        false,
        propertyChanged: OnHasRemovePropertyChanged
    );

    private static void OnHasRemovePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VCheckBoxButton).CheckBoxButtonRemoveButton.IsVisible = (bool)newValue;
    }

    private void VCheckBoxButton_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VCheckBoxButton),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBoxButton = (VCheckBoxButton)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vCheckBoxButton.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBoxButton = (VCheckBoxButton)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                vCheckBoxButton.IsEnabled = newcommand.CanExecute(vCheckBoxButton.CommandParameter);
                newcommand.CanExecuteChanged += vCheckBoxButton.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VCheckBoxButton),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBoxButton = (VCheckBoxButton)bindable;
            if (vCheckBoxButton.Command != null)
            {
                vCheckBoxButton.IsEnabled = vCheckBoxButton.Command.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(VCheckBoxButton),
        false,
        BindingMode.TwoWay,
        propertyChanged: OnIsCheckedPropertyChanged
    );

    private static void OnIsCheckedPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        var vCheckBoxButton = (VCheckBoxButton)bindable;
        if (newValue != oldValue)
        {
            vCheckBoxButton.GoToState((bool)newValue);
        }
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(VCheckBoxButton),
        string.Empty
    );

    public IView ContentSlot { get; set; }

    public bool IsChecked
    {
        get { return (bool)GetValue(IsCheckedProperty); }
        set { SetValue(IsCheckedProperty, value); }
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool HasRemove
    {
        get { return (bool)GetValue(HasRemoveProperty); }
        set { SetValue(HasRemoveProperty, value); }
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

    public VCheckBoxButton()
    {
        InitializeComponent();
        Loaded += VCheckBoxButton_Loaded;
        GoToState(IsChecked);
    }

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    public async void SelTapped(object sender, TappedEventArgs e)
    {
        IsChecked = !IsChecked;
        if (!IsEnabled)
        {
            return;
        }

        Command?.Execute(CommandParameter);
        GoToState(IsChecked);
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public void GoToState(bool isChecked)
    {
        string visualState = isChecked ? "IsChecked" : "Normal";
        VisualStateManager.GoToState(this, visualState);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        RemoveButtonClicked?.Invoke(this, e);
    }
}
