using System.Windows.Input;

namespace VControl.Controls;

public partial class VPlaceholderView : ContentView
{
    public event EventHandler OnOkButtonClicked;

    public VPlaceholderView()
    {
        InitializeComponent();
        Loaded += VPlaceholderView_LoadedAsync;
    }

    private async void VPlaceholderView_LoadedAsync(object? sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
        await Task.Delay(1000);
        await this.OkButton.FadeTo(1);
    }

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        nameof(TitleText),
        typeof(string),
        typeof(VPlaceholderView),
        "TITLE HERE"
    );

    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
        nameof(ButtonText),
        typeof(string),
        typeof(VPlaceholderView),
        "BUTTON"
    );

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VPlaceholderView)
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VPlaceholderView)
    );

    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(
        nameof(ProgressColor),
        typeof(Color),
        typeof(VPlaceholderView)
    );

    public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
        nameof(IconSource),
        typeof(string),
        typeof(VPlaceholderView),
        "v_control_empty.png"
    );

    public static readonly BindableProperty HasOkButtonProperty = BindableProperty.Create(
        nameof(HasOkButton),
        typeof(bool),
        typeof(VPlaceholderView),
        true
    );

    public IView ContentSlot { get; set; }

    public string IconSource
    {
        get { return (string)GetValue(IconSourceProperty); }
        set { SetValue(IconSourceProperty, value); }
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public string TitleText
    {
        get { return (string)GetValue(TitleTextProperty); }
        set { SetValue(TitleTextProperty, value); }
    }

    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set { SetValue(CommandProperty, value); }
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set { SetValue(CommandParameterProperty, value); }
    }

    public bool HasOkButton
    {
        get { return (bool)GetValue(HasOkButtonProperty); }
        set { SetValue(HasOkButtonProperty, value); }
    }

    private void OkButton_Clicked(object sender, EventArgs e)
    {
        OnOkButtonClicked?.Invoke(this, EventArgs.Empty);

        if (Command is not null && Command.CanExecute(CommandParameter))
            Command.Execute(CommandParameter);
    }
}
