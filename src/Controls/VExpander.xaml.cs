using VControl.Controls.VExpandable;

namespace VControl.Controls;

public partial class VExpander : ContentView
{
    public event EventHandler<ExpandedChangedEventArgs> ExpandedChanged;

    public static BindableProperty ExpanderAnimationProperty = BindableProperty.Create(
        nameof(ExpanderAnimation),
        typeof(IExpanderAnimation),
        typeof(VExpander),
        new ExpanderAnimation()
    );

    public IExpanderAnimation ExpanderAnimation
    {
        get { return (IExpanderAnimation)GetValue(ExpanderAnimationProperty); }
        set { SetValue(ExpanderAnimationProperty, value); }
    }

    public static readonly BindableProperty ExpandDirectionProperty = BindableProperty.Create(
        nameof(ExpandDirection),
        typeof(ExpandDirection),
        typeof(VExpander),
        ExpandDirection.Down,
        propertyChanged: OnExpandDirectionChanged
    );

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
    nameof(TitleText),
    typeof(string),
    typeof(VExpander),
    "TITLE HERE"
);
    public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(
        nameof(TitleTextColor),
        typeof(Color),
        typeof(VExpander),
        default
    );


    static void OnExpandDirectionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VExpander)?.UpdateExpandDirection();
    }

    public ExpandDirection ExpandDirection
    {
        get => (ExpandDirection)GetValue(ExpandDirectionProperty);
        set => SetValue(ExpandDirectionProperty, value);
    }

    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
        nameof(IsExpanded),
        typeof(bool),
        typeof(VExpander),
        true,
        propertyChanged: OnIsExpandedChanged
    );

    static async void OnIsExpandedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        await (bindable as VExpander)?.UpdateIsExpandedAsync();
    }

    public string TitleText
    {
        get { return (string)GetValue(TitleTextProperty); }
        set { SetValue(TitleTextProperty, value); }
    }

    public Color TitleTextColor
    {
        get { return (Color)GetValue(TitleTextColorProperty); }
        set { SetValue(TitleTextColorProperty, value); }
    }

    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    public VExpander()
    {
        InitializeComponent();
        Loaded += VExpander_Loaded;
        UpdateExpandDirection();
        if (TitleTextColor == default)
        {
            object textColor = default;
            Application.Current?.Resources.TryGetValue("OnSurface", out textColor);
            TitleTextColor = textColor as Color;
        }
    }

    private void VExpander_Loaded(object sender, EventArgs e)
    {
        if (this.HeaderSlot != default)
        {
            (this.FindByName("HeaderContent") as ContentView).Content = (View)this.HeaderSlot;
        }

        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public IView HeaderSlot { get; set; }

    public IView ContentSlot { get; set; }

    private async Task UpdateIsExpandedAsync()
    {
        if (IsExpanded)
        {
            (this.FindByName("MainContent") as ContentView).IsVisible = true;

            await ExpanderAnimation.OnExpand(this.FindByName("MainContent") as ContentView);
        }
        else
        {
            await ExpanderAnimation.OnCollapse(this.FindByName("MainContent") as ContentView);

            (this.FindByName("MainContent") as ContentView).IsVisible = false;
        }

        ExpandedChanged?.Invoke(this, new ExpandedChangedEventArgs(this.IsExpanded));
    }

    private void UpdateExpandDirection()
    {

        var header = (this.FindByName("HeaderContent") as ContentView);
        var content = (this.FindByName("MainContent") as ContentView);

        if (this.MainLayout is null)
            return;

        this.MainLayout.Children.Remove(header);
        this.MainLayout.Children.Remove(content);

        this.MainLayout.ColumnDefinitions.Clear();
        this.MainLayout.RowDefinitions.Clear();

        switch (ExpandDirection)
        {
            case ExpandDirection.Down:
                this.MainLayout.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                this.MainLayout.RowDefinitions.Add(new RowDefinition(GridLength.Star));

                this.MainLayout.Children.Add(header);
                Grid.SetRow(header as BindableObject, 0);
                this.MainLayout.Children.Add(content);
                Grid.SetRow(content as BindableObject, 1);
                break;
            case ExpandDirection.Up:
                this.MainLayout.RowDefinitions.Add(new RowDefinition(GridLength.Star));
                this.MainLayout.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

                this.MainLayout.Children.Add(content);
                Grid.SetRow(content as BindableObject, 0);
                this.MainLayout.Children.Add(header);
                Grid.SetRow(header as BindableObject, 1);
                break;
            default:
                throw new NotSupportedException();
        }
    }

    private void OnHeaderContentTapped(object sender, TappedEventArgs e)
    {
        IsExpanded = !IsExpanded;
    }
}
