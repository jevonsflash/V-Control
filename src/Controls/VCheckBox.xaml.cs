using System.Windows.Input;

namespace VControl.Controls;

public partial class VCheckBox : ContentView
{

    public event EventHandler Clicked;

    private void VCheckBox_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VCheckBox),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VCheckBox)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vCheckBox.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VCheckBox)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                vCheckBox.IsEnabled = newcommand.CanExecute(vCheckBox.CommandParameter);
                newcommand.CanExecuteChanged += vCheckBox.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VCheckBox),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VCheckBox)bindable;
            if (vCheckBox.Command != null)
            {
                vCheckBox.IsEnabled = vCheckBox.Command.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(VCheckBox),
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
        var vCheckBox = (VCheckBox)bindable;
        if (newValue != oldValue)
        {
            vCheckBox.GoToState((bool)newValue);
        }
    }

    public static readonly BindableProperty IsIndeterminateProperty = BindableProperty.Create(
        nameof(IsIndeterminate),
        typeof(bool),
        typeof(VCheckBox),
        false,
        BindingMode.TwoWay,
        propertyChanged: OnIsIndeterminatePropertyChanged
    );

    private static void OnIsIndeterminatePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        var vCheckBox = (VCheckBox)bindable;
        vCheckBox.GoToIndeterminateState((bool)newValue);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(VCheckBox),
        string.Empty
    );

    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VCheckBox),
        "\uF00C",
        defaultBindingMode: BindingMode.OneWay
    );

    public IView ContentSlot { get; set; }

    public bool IsChecked
    {
        get { return (bool)GetValue(IsCheckedProperty); }
        set { SetValue(IsCheckedProperty, value); }
    }
    public bool IsIndeterminate
    {
        get { return (bool)GetValue(IsIndeterminateProperty); }
        set { SetValue(IsIndeterminateProperty, value); }
    }
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
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

    public VCheckBox()
    {
        InitializeComponent();
        Loaded += VCheckBox_Loaded;
        PropertyChanged += VCheckBox_PropertyChanged;
        GoToState(IsChecked);
    }

    private void VCheckBox_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(IsEnabled))
        {

        }
    }

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    public async void SelTapped(object sender, TappedEventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        IsChecked = !IsChecked;
        this.IsIndeterminate = false;

        Command?.Execute(CommandParameter);
        GoToState(IsChecked);
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public void GoToState(bool isChecked)
    {
        string visualState = isChecked ? "IsChecked" : "Normal";
        VisualStateManager.GoToState(this, visualState);
    }

    public void GoToIndeterminateState(bool isIndeterminate)
    {
        if (isIndeterminate)
        {
            VisualStateManager.GoToState(this, "IsIndeterminate");
            this.IconText = "\uF068";
        }
        else
        {
            this.IconText = "\uF00C";
            GoToState(this.IsChecked);
        }
    }
}
