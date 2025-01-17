using System.Collections;
using System.Windows.Input;

namespace VControl.Controls;

public partial class VUploader : ContentView
{
    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
        nameof(IconText),
        typeof(string),
        typeof(VCard),
        "\uF0EE",
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty UploadCommandProperty = BindableProperty.Create(
        nameof(UploadCommand),
        typeof(ICommand),
        typeof(VUploader),
        default(ICommand)
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VUploader),
        default(object)
    );

    public static readonly BindableProperty TipProperty = BindableProperty.Create(
        nameof(Tip),
        typeof(string),
        typeof(VUploader),
        string.Empty,
        //propertyChanged: OnTipPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty RemoveCommandProperty = BindableProperty.Create(
        nameof(RemoveCommand),
        typeof(ICommand),
        typeof(VUploader)
    );

    public static readonly BindableProperty HasRemoveProperty = BindableProperty.Create(
        nameof(HasRemove),
        typeof(bool),
        typeof(VUploader),
        true,
        propertyChanged: OnHasRemovePropertyChanged
    );

    private static void OnHasRemovePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    ) { }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VUploader)
    );

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(VUploader),
        null,
        propertyChanged: OnItemsSourcePropertyChanged
    );

    private static void OnItemsSourcePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    ) { }

    public string IconText
    {
        get => (string)GetValue(IconTextProperty);
        set => SetValue(IconTextProperty, value);
    }

    public ICommand RemoveCommand
    {
        get { return (ICommand)GetValue(RemoveCommandProperty); }
        set { SetValue(RemoveCommandProperty, value); }
    }

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public bool HasRemove
    {
        get { return (bool)GetValue(HasRemoveProperty); }
        set { SetValue(HasRemoveProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public string Tip
    {
        get => (string)GetValue(TipProperty);
        set => SetValue(TipProperty, value);
    }

    public ICommand UploadCommand
    {
        get { return (ICommand)GetValue(UploadCommandProperty); }
        set { SetValue(UploadCommandProperty, value); }
    }

    public VUploader()
    {
        InitializeComponent();
    }

    private void OnUploadTapped(object sender, TappedEventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }

        UploadCommand?.Execute(CommandParameter);
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        var CommandParameter = (sender as Button).BindingContext;
        this.Command?.Execute(CommandParameter);
    }

    private void RemoveButton_Clicked(object sender, EventArgs e)
    {
        if (!IsEnabled)
        {
            return;
        }
        var removeCommandParameter = (sender as Button).BindingContext;
        RemoveCommand?.Execute(removeCommandParameter);
    }
}
