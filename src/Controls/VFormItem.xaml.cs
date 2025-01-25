using System.Windows.Input;

namespace VControl.Controls;

public partial class VFormItem : ContentView
{
    public VFormItem()
    {
        InitializeComponent();
        Loaded += VFormItem_Loaded;
        this.IsRequiredMark = "*";
    }

    private void VFormItem_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
        if (this.InfoSlot != default)
        {
            (this.FindByName("InfoContent") as ContentView).Content = (View)this.InfoSlot;
        }

        HasInfo = !string.IsNullOrEmpty(this.InfoText) || InfoSlot != default;
        HasTitle = !string.IsNullOrEmpty(this.TitleText);
    }

    public IView ContentSlot { get; set; }

    public IView InfoSlot { get; set; }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VFormItem),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vFormItem = (VFormItem)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vFormItem.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vFormItem = (VFormItem)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                vFormItem.IsEnabled = newcommand.CanExecute(vFormItem.CommandParameter);
                newcommand.CanExecuteChanged += vFormItem.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VFormItem),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vFormItem = (VFormItem)bindable;
            if (vFormItem.Command != null)
            {
                vFormItem.IsEnabled = vFormItem.Command.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        nameof(TitleText),
        typeof(string),
        typeof(VFormItem),
        "",
        propertyChanged: OnTitleTextPropertyChanged
    );

    private static void OnTitleTextPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VFormItem).HasTitle = !string.IsNullOrEmpty(newValue as string);
    }

    public static readonly BindableProperty ValidateTextProperty = BindableProperty.Create(
        nameof(ValidateText),
        typeof(string),
        typeof(VFormItem),
        "Invalid! The value should be something"
    );
    public static readonly BindableProperty InfoTextProperty = BindableProperty.Create(
        nameof(InfoText),
        typeof(string),
        typeof(VFormItem),
        "",
        propertyChanged: OnInfoTextPropertyChanged
    );

    private static void OnInfoTextPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if (string.IsNullOrEmpty(newValue as string) && (bindable as VFormItem).InfoSlot == default)
        {
            (bindable as VFormItem).HasInfo = false;
        }
        else
        {
            (bindable as VFormItem).HasInfo = true;
        }
    }

    public static readonly BindableProperty HasTitleProperty = BindableProperty.Create(
        nameof(HasTitle),
        typeof(bool),
        typeof(VFormItem),
        true,
        BindingMode.TwoWay
    );
    public static readonly BindableProperty HasInfoProperty = BindableProperty.Create(
        nameof(HasInfo),
        typeof(bool),
        typeof(VFormItem),
        true,
        BindingMode.TwoWay
    );

    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(
        nameof(IsRequired),
        typeof(bool),
        typeof(VFormItem),
        true,
        propertyChanged: OnIsRequiredProperty
    );

    private static void OnIsRequiredProperty(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VFormItem).IsRequiredMark = (bool)newValue ? "*" : string.Empty;
    }

    public static readonly BindableProperty IsShowInfoProperty = BindableProperty.Create(
        nameof(IsShowInfo),
        typeof(bool),
        typeof(VFormItem),
        false,
        BindingMode.TwoWay
    );

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
        nameof(IsValid),
        typeof(bool),
        typeof(VFormItem),
        false
    );

    public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(
        nameof(TitleTextColor),
        typeof(Color),
        typeof(VFormItem),
        null
    );

    private string _isRequiredMark;

    public string IsRequiredMark
    {
        get { return _isRequiredMark; }
        set
        {
            _isRequiredMark = value;
            OnPropertyChanged();
        }
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

    public string TitleText
    {
        get { return (string)GetValue(TitleTextProperty); }
        set { SetValue(TitleTextProperty, value); }
    }

    public string ValidateText
    {
        get { return (string)GetValue(ValidateTextProperty); }
        set { SetValue(ValidateTextProperty, value); }
    }

    public string InfoText
    {
        get { return (string)GetValue(InfoTextProperty); }
        set { SetValue(InfoTextProperty, value); }
    }

    public bool HasTitle
    {
        get { return (bool)GetValue(HasTitleProperty); }
        set { SetValue(HasTitleProperty, value); }
    }
    public bool HasInfo
    {
        get { return (bool)GetValue(HasInfoProperty); }
        set { SetValue(HasInfoProperty, value); }
    }

    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }

    public bool IsShowInfo
    {
        get { return (bool)GetValue(IsShowInfoProperty); }
        set { SetValue(IsShowInfoProperty, value); }
    }

    public bool IsValid
    {
        get { return (bool)GetValue(IsValidProperty); }
        set { SetValue(IsValidProperty, value); }
    }

    public Color TitleTextColor
    {
        get { return (Color)GetValue(TitleTextColorProperty); }
        set { SetValue(TitleTextColorProperty, value); }
    }

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = Command.CanExecute(CommandParameter);
    }

    private void ShowInfoTapped(object sender, TappedEventArgs e)
    {
        this.IsShowInfo = !this.IsShowInfo;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }

        Command?.Execute(CommandParameter);
    }
}
