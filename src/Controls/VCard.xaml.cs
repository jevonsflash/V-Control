using System.Windows.Input;

namespace VControl.Controls;

public partial class VCard : ContentView
{
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VCard),
        default(ICommand)
    );
    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VCard),
        default(object)
    );

    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(
        nameof(CardTitle),
        typeof(string),
        typeof(VCard),
        string.Empty,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty CardDetailProperty = BindableProperty.Create(
        nameof(CardDetail),
        typeof(string),
        typeof(VCard),
        string.Empty,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnCardDetailPropertyChanged
    );

    private static void OnCardDetailPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        if ((bindable as VCard).ContentSlot != default)
        {
            (bindable as VCard).MainSpliter.IsVisible = true;
        }
        (bindable as VCard).MainSpliter.IsVisible = !string.IsNullOrEmpty(newValue as string);
    }

    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VCard),
        "",
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty IsCardEnabledProperty = BindableProperty.Create(
        nameof(IsCardEnabled),
        typeof(bool),
        typeof(VCard),
        true,
        //propertyChanged: OnEntryTextPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string CardDetail
    {
        get => (string)GetValue(CardDetailProperty);
        set => SetValue(CardDetailProperty, value);
    }

    public string IconText
    {
        get => (string)GetValue(IconTextProperty);
        set => SetValue(IconTextProperty, value);
    }

    public bool IsCardEnabled
    {
        get => (bool)GetValue(IsCardEnabledProperty);
        set => SetValue(IsCardEnabledProperty, value);
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

    public VCard()
    {
        InitializeComponent();
        Loaded += VCard_Loaded;
    }

    private void VCard_Loaded(object sender, EventArgs e)
    {
        if (this.HeaderSlot != default)
        {
            (this.FindByName("HeaderContent") as ContentView).Content = (View)this.HeaderSlot;
        }

        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
            MainSpliter.IsVisible = true;
        }

        if (this.FooterSlot != default)
        {
            FooterSplitLine.IsVisible = true;
            (this.FindByName("FooterContent") as ContentView).Content = (View)this.FooterSlot;
        }
    }

    public IView HeaderSlot { get; set; }

    public IView ContentSlot { get; set; }

    public IView FooterSlot { get; set; }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }

        Command?.Execute(CommandParameter);
    }
}
