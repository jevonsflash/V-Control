using System.Collections;
using System.Windows.Input;


namespace VControl.Samples.Views;

public partial class VCollectionItemView : ContentPageBase<VCollectionItemViewModel>
{

    public event EventHandler Clicked;
    public event EventHandler RemoveButtonClicked;
    public event EventHandler EditButtonClicked;
    public VCollectionItem()
    {
        InitializeComponent();
        Loaded += VCollectionItem_Loaded;
    }

    private void VCollectionItem_Loaded(object sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
        if (this.OperationsSlot != default)
        {
            (this.FindByName("OperationsContent") as ContentView).Content = (View)this.OperationsSlot;
        }
    }



    public IView ContentSlot
    {
        get;
        set;
    }

    public IView OperationsSlot
    {
        get;
        set;
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(VCollectionItem), default(object));

    public static readonly BindableProperty EditCommandProperty = BindableProperty.Create("EditCommand", typeof(ICommand), typeof(Entry));
    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create("RemoveCommand", typeof(ICommand), typeof(Entry));


    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(VCollectionItem), "TITLE HERE");
    public static readonly BindableProperty OperationsTextProperty = BindableProperty.Create(nameof(OperationsText), typeof(string), typeof(VCollectionItem), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nam imperdiet facilisi eleifend quam malesuada malesuada vehicula morbi sociis eleifend facilisi sociosqu. ");
    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(nameof(HasRemove), typeof(bool), typeof(VCollectionItem), true);
    public static readonly BindableProperty HasEditProperty = BindableProperty.Create(nameof(HasEdit),
        typeof(bool), typeof(VCollectionItem), true);



    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(VCollectionItem), true);







    public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(VCollectionItem), null);



    public ICommand EditCommand
    {
        get
        {
            return (ICommand)GetValue(EditCommandProperty);
        }
        set
        {
            SetValue(EditCommandProperty, value);
        }
    }


    public ICommand RemoveCommand
    {
        get
        {
            return (ICommand)GetValue(RemoveCommandProperty);
        }
        set
        {
            SetValue(RemoveCommandProperty, value);
        }
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

  

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        EditButtonClicked?.Invoke(this, EventArgs.Empty);

    }

    private void RemoveButton_Clicked(object sender, EventArgs e)
    {
        RemoveButtonClicked?.Invoke(this, EventArgs.Empty);

    }
}