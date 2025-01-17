using System.Windows.Input;

namespace VControl.Controls;

public partial class VTopAppBar : ContentView
{
    private double _midTitleScale = 0.75;
    public event EventHandler NavigationClicked;

    public VTopAppBar()
    {
        InitializeComponent();
        Loaded += VTopAppBar_Loaded;
        this.UpdateTitleStyle();
    }

    private void VTopAppBar_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
        if (this.OperationsSlot != default)
        {
            (this.FindByName("OperationsContent") as ContentView).Content = (View)
                this.OperationsSlot;
        }
    }

    public IView ContentSlot { get; set; }

    public IView OperationsSlot { get; set; }

    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VTopAppBar),
        "\uF060",
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VTopAppBar),
        default(object)
    );

    public static readonly BindableProperty MoreCommandProperty = BindableProperty.Create(
        nameof(MoreCommand),
        typeof(ICommand),
        typeof(VTopAppBar)
    );
    public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(
        nameof(NavigationCommand),
        typeof(ICommand),
        typeof(VTopAppBar)
    );

    public static readonly BindableProperty SinkingDistanceProperty = BindableProperty.Create(
        nameof(SinkingDistance),
        typeof(double),
        typeof(VTopAppBar),
        60.0d,
        propertyChanged: OnSinkingDistancePropertyChanged
    );

    private static void OnSinkingDistancePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VTopAppBar)?.UpdateTopAppBarStyle();
    }

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        nameof(TitleText),
        typeof(string),
        typeof(VTopAppBar),
        "TITLE HERE"
    );
    public static readonly BindableProperty OperationsTextProperty = BindableProperty.Create(
        nameof(OperationsText),
        typeof(string),
        typeof(VTopAppBar),
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nam imperdiet facilisi eleifend quam malesuada malesuada vehicula morbi sociis eleifend facilisi sociosqu. "
    );
    public static readonly BindableProperty HasNavigationProperty = BindableProperty.Create(
        nameof(HasNavigation),
        typeof(bool),
        typeof(VTopAppBar),
        true
    );
    public static readonly BindableProperty HasMoreProperty = BindableProperty.Create(
        nameof(HasMore),
        typeof(bool),
        typeof(VTopAppBar),
        true
    );

    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(
        nameof(Progress),
        typeof(double),
        typeof(VTopAppBar),
        0.5,
        propertyChanged: OnProgressPropertyChanged
    );

    private static void OnProgressPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        var obj = (VTopAppBar)bindable;
        obj.UpdateProgress((double)newValue);
    }

    public static readonly BindableProperty TopAppBarStyleProperty = BindableProperty.Create(
        nameof(TopAppBarStyle),
        typeof(VTopAppBarStyles),
        typeof(VTopAppBar),
        VTopAppBarStyles.Fixed,
        propertyChanged: OnTopAppBarStylePropertyChanged
    );

    private static void OnTopAppBarStylePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VTopAppBar)?.UpdateTopAppBarStyle();
        (bindable as VTopAppBar)?.UpdateTitleStyle();
    }

    public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(
        nameof(TitleTextColor),
        typeof(Color),
        typeof(VTopAppBar),
        Colors.Black
    );

    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        nameof(IsBusy),
        typeof(bool),
        typeof(VTopAppBar),
        false,
        propertyChanged: OnIsBusyChanged
    );

    static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VTopAppBar)?.OnIsBusyChanged();
    }

    protected async void OnIsBusyChanged()
    {
        if (IsBusy)
        {
            MainActivityIndicator.IsRunning = true;
            await MainActivityIndicator.FadeTo(1);
        }
        else
        {
            MainActivityIndicator.IsRunning = false;
            await MainActivityIndicator.FadeTo(0);
        }
    }

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    public ICommand MoreCommand
    {
        get { return (ICommand)GetValue(MoreCommandProperty); }
        set { SetValue(MoreCommandProperty, value); }
    }

    public ICommand NavigationCommand
    {
        get { return (ICommand)GetValue(NavigationCommandProperty); }
        set { SetValue(NavigationCommandProperty, value); }
    }

    public double SinkingDistance
    {
        get => (double)GetValue(SinkingDistanceProperty);
        set => SetValue(SinkingDistanceProperty, value);
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

    public string OperationsText
    {
        get { return (string)GetValue(OperationsTextProperty); }
        set { SetValue(OperationsTextProperty, value); }
    }

    public bool HasNavigation
    {
        get { return (bool)GetValue(HasNavigationProperty); }
        set { SetValue(HasNavigationProperty, value); }
    }
    public bool HasMore
    {
        get { return (bool)GetValue(HasMoreProperty); }
        set { SetValue(HasMoreProperty, value); }
    }

    public VTopAppBarStyles TopAppBarStyle
    {
        get { return (VTopAppBarStyles)GetValue(TopAppBarStyleProperty); }
        set { SetValue(TopAppBarStyleProperty, value); }
    }

    public Color TitleTextColor
    {
        get { return (Color)GetValue(TitleTextColorProperty); }
        set { SetValue(TitleTextColorProperty, value); }
    }
    public double Progress
    {
        get { return (double)GetValue(ProgressProperty); }
        set { SetValue(ProgressProperty, value); }
    }

    public string IconText
    {
        get => (string)GetValue(IconTextProperty);
        set => SetValue(IconTextProperty, value);
    }

    private void UpdateTopAppBarStyle()
    {
        if (this.MainLayout is null)
            return;

        switch (TopAppBarStyle)
        {
            case VTopAppBarStyles.Fixed:

                Grid.SetRow(MainContent as BindableObject, 0);
                Grid.SetColumn(MainContent as BindableObject, 1);
                this.MainLayout.RowDefinitions[1].Height = 0;
                break;
            case VTopAppBarStyles.Active:

                Grid.SetRow(MainContent as BindableObject, 1);
                Grid.SetColumn(MainContent as BindableObject, 0);
                Grid.SetColumnSpan(MainContent as BindableObject, 2);
                this.MainLayout.RowDefinitions[1].Height = SinkingDistance;

                break;
            default:
                throw new NotSupportedException();
        }
    }

    private void UpdateTitleStyle()
    {
        if ((this.FindByName("MainContent") as ContentView).Content is null)
            return;

        if ((this.FindByName("MainContent") as ContentView).Content is View label)
        {
            switch (TopAppBarStyle)
            {
                case VTopAppBarStyles.Fixed:
                    label.HorizontalOptions = LayoutOptions.Start;
                    label.Scale = _midTitleScale;
                    label.Margin = new Thickness(0, 0, 0, 0);
                    break;

                case VTopAppBarStyles.Active:
                    label.HorizontalOptions = LayoutOptions.Start;
                    label.Scale = 1.0;
                    label.Margin = new Thickness(0, 20, 0, 0);
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
    }

    private void UpdateProgress(double t)
    {
        if (t > 0.9)
        {
            if ((this.FindByName("MainContent") as ContentView).Content is null)
                return;

            if ((this.FindByName("MainContent") as ContentView).Content is View label)
            {
                if (TopAppBarStyle == VTopAppBarStyles.Active)
                {
                    label.Scale = _midTitleScale;
                    Grid.SetRow(MainContent as BindableObject, 0);
                    Grid.SetColumn(MainContent as BindableObject, 1);
                    label.Margin = new Thickness(0, 0, 0, 0);
                    label.TranslationY = 0;
                }
            }
        }
        else
        {
            var r = t / 0.9;
            if ((this.FindByName("MainContent") as ContentView).Content is null)
                return;

            if ((this.FindByName("MainContent") as ContentView).Content is View label)
            {
                if (TopAppBarStyle == VTopAppBarStyles.Active)
                {
                    if (TopAppBarStyle == VTopAppBarStyles.Active)
                    {
                        label.Margin = new Thickness(0, 20, 0, 0);
                        label.Scale = 1.0 - (1.0 - _midTitleScale) * r;
                    }
                    else
                    {
                        label.Margin = new Thickness(0, -10, 0, 0);
                    }
                    Grid.SetRow(MainContent as BindableObject, 1);
                    Grid.SetColumn(MainContent as BindableObject, 0);
                    Grid.SetColumnSpan(MainContent as BindableObject, 2);

                    label.TranslationY = -SinkingDistance * r;
                }
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        NavigationClicked?.Invoke(this, e);
    }
}
