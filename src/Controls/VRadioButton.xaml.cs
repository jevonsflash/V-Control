using System.Windows.Input;

namespace VControl.Controls;

public partial class VRadioButton : ContentView
{

    public event EventHandler Clicked;

    private void VRadioButton_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VRadioButton),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VRadioButton)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vCheckBox.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VRadioButton)bindable;
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
        typeof(VRadioButton),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vCheckBox = (VRadioButton)bindable;
            if (vCheckBox.Command != null)
            {
                vCheckBox.IsEnabled = vCheckBox.Command.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(VRadioButton),
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
        var vCheckBox = (VRadioButton)bindable;
        if (newValue != oldValue)
        {
            vCheckBox.GoToState((bool)newValue);
        }
    }

 

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(VRadioButton),
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


    public VRadioButton()
    {
        InitializeComponent();
        Loaded += VRadioButton_Loaded;
        PropertyChanged += VRadioButton_PropertyChanged;
        GoToState(IsChecked);
    }

    private void VRadioButton_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
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

        Command?.Execute(CommandParameter);
        GoToState(IsChecked);
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public void GoToState(bool isChecked)
    {
        string visualState = isChecked ? "IsChecked" : "Normal";
        VisualStateManager.GoToState(this, visualState);
    }


}
