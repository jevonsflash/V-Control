using System.Windows.Input;

namespace VControl.Controls;

public partial class VSearchBar : ContentView
{
    public VSearchBar()
    {
        InitializeComponent();
        Loaded += VSearchBar_Loaded;
    }

    private void VSearchBar_Loaded(object? sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public static readonly BindableProperty AddCommandProperty = BindableProperty.Create(
        nameof(AddCommand),
        typeof(ICommand),
        typeof(VSearchBar),
        default(ICommand),
        propertyChanging: (bindable, oldvalue, newvalue) =>
        {
            var vSearchBar = (VSearchBar)bindable;
            var oldcommand = (ICommand)oldvalue;
            if (oldcommand != null)
                oldcommand.CanExecuteChanged -= vSearchBar.OnCommandCanExecuteChanged;
        },
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vSearchBar = (VSearchBar)bindable;
            var newcommand = (ICommand)newvalue;
            if (newcommand != null)
            {
                vSearchBar.IsEnabled = newcommand.CanExecute(vSearchBar.CommandParameter);
                newcommand.CanExecuteChanged += vSearchBar.OnCommandCanExecuteChanged;
            }
        }
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VSearchBar),
        default(object),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var vSearchBar = (VSearchBar)bindable;
            if (vSearchBar.AddCommand != null)
            {
                vSearchBar.IsEnabled = vSearchBar.AddCommand.CanExecute(newvalue);
            }
        }
    );

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(VSearchBar),
        default(string),
        BindingMode.TwoWay
    );
    public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
        nameof(PlaceHolder),
        typeof(string),
        typeof(VSearchBar),
        "Search"
    );
    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VSearchBar),
        "\uF002"
    );
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        nameof(SearchCommand),
        typeof(ICommand),
        typeof(VSearchBar)
    );

    public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(
        nameof(TitleColor),
        typeof(Color),
        typeof(VSearchBar),
        null
    );
    public static readonly BindableProperty HasSearchButtonProperty = BindableProperty.Create(
        nameof(HasSearchButton),
        typeof(bool),
        typeof(VCollectionItem),
        true
    );

    public IView ContentSlot { get; set; }


    public bool HasSearchButton
    {
        get { return (bool)GetValue(HasSearchButtonProperty); }
        set { SetValue(HasSearchButtonProperty, value); }
    }

    public ICommand AddCommand
    {
        get { return (ICommand)GetValue(AddCommandProperty); }
        set { SetValue(AddCommandProperty, value); }
    }

    public ICommand SearchCommand
    {
        get { return (ICommand)GetValue(SearchCommandProperty); }
        set { SetValue(SearchCommandProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public string PlaceHolder
    {
        get { return (string)GetValue(PlaceHolderProperty); }
        set { SetValue(PlaceHolderProperty, value); }
    }

    public string IconText
    {
        get { return (string)GetValue(IconTextProperty); }
        set { SetValue(IconTextProperty, value); }
    }

    public Color TitleColor
    {
        get { return (Color)GetValue(TitleColorProperty); }
        set { SetValue(TitleColorProperty, value); }
    }

    protected void OnAddTapped()
    {
        if (!IsEnabled)
        {
            return;
        }

        AddCommand?.Execute(CommandParameter);
    }

    void OnCommandCanExecuteChanged(object sender, EventArgs eventArgs)
    {
        IsEnabled = AddCommand.CanExecute(CommandParameter);
    }
}
