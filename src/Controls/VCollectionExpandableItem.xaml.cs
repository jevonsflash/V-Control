using System.Windows.Input;
using VControl.Controls.VExpandable;

namespace VControl.Controls;

public partial class VCollectionExpandableItem : ContentView
{
    public event EventHandler<ExpandedChangedEventArgs> ExpandedChanged;

    public VCollectionExpandableItem()
    {
        InitializeComponent();
        Loaded += VCollectionExpandableItem_Loaded;
        GoToState(IsExpanded);
    }

    private void VCollectionExpandableItem_Loaded(object sender, EventArgs e)
    {
        if (this.HeaderSlot != default)
        {
            (this.FindByName("HeaderContent") as ContentView).Content = (View)this.HeaderSlot;
        }

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

    public IView HeaderSlot { get; set; }

    public IView ContentSlot { get; set; }

    public IView OperationsSlot { get; set; }

    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
        nameof(IsExpanded),
        typeof(bool),
        typeof(VCollectionExpandableItem),
        false,
        propertyChanged: OnIsExpandedPropertyChanged
    );

    private static void OnIsExpandedPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        var VCollectionExpandableItem = (VCollectionExpandableItem)bindable;
        if (newValue != oldValue)
        {
            VCollectionExpandableItem.GoToState((bool)newValue);
        }
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VCollectionExpandableItem),
        default(object)
    );

    public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
        nameof(EditCommand),
        typeof(ICommand),
        typeof(VCollectionExpandableItem)
    );
    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(
        nameof(RemoveCommand),
        typeof(ICommand),
        typeof(VCollectionExpandableItem)
    );

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        nameof(TitleText),
        typeof(string),
        typeof(VCollectionExpandableItem),
        "TITLE HERE"
    );
    public static readonly BindableProperty OperationsTextProperty = BindableProperty.Create(
        nameof(OperationsText),
        typeof(string),
        typeof(VCollectionExpandableItem),
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nam imperdiet facilisi eleifend quam malesuada malesuada vehicula morbi sociis eleifend facilisi sociosqu. "
    );
    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(
        nameof(HasRemove),
        typeof(bool),
        typeof(VCollectionExpandableItem),
        true
    );
    public static readonly BindableProperty HasEditProperty = BindableProperty.Create(
        nameof(HasEdit),
        typeof(bool),
        typeof(VCollectionExpandableItem),
        true
    );

    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(
        nameof(IsRequired),
        typeof(bool),
        typeof(VCollectionExpandableItem),
        true
    );

    public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(
        nameof(TitleTextColor),
        typeof(Color),
        typeof(VCollectionExpandableItem),
        null
    );

    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    private void ExpandedTapped(object sender, ExpandedChangedEventArgs e)
    {
        this.IsExpanded = e.IsExpanded;
        ExpandedChanged?.Invoke(this, e);
    }

    public ICommand EditCommand
    {
        get { return (ICommand)GetValue(EditCommandProperty); }
        set { SetValue(EditCommandProperty, value); }
    }

    public ICommand RemoveCommand
    {
        get { return (ICommand)GetValue(RemoveCommandProperty); }
        set { SetValue(RemoveCommandProperty, value); }
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

    public bool HasRemove
    {
        get { return (bool)GetValue(HasRemoveProperty); }
        set { SetValue(HasRemoveProperty, value); }
    }
    public bool HasEdit
    {
        get { return (bool)GetValue(HasEditProperty); }
        set { SetValue(HasEditProperty, value); }
    }

    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }

    public Color TitleTextColor
    {
        get { return (Color)GetValue(TitleTextColorProperty); }
        set { SetValue(TitleTextColorProperty, value); }
    }

    public void GoToState(bool isExpended)
    {
        string visualState = isExpended ? "Expended" : "Collapsed";
        VisualStateManager.GoToState(this, visualState);
    }
}
