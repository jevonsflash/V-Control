using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace VControl.Controls;

public partial class VButton : VTouchContentView
{
    public VButton()
    {
        InitializeComponent();
        Loaded += VButton_Loaded;
        UpdateIsEnabled();
        SetButtonStyle(this.ButtonStyle);
    }

    private void VButton_Loaded(object? sender, EventArgs e)
    {
        if (this.ContentSlot != default)
        {
            (this.FindByName("MainContent") as ContentView).Content = (View)this.ContentSlot;
        }
    }

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        nameof(TitleText),
        typeof(string),
        typeof(VButton),
        "TITLE HERE"
    );

    public static readonly BindableProperty BorderBrushProperty = BindableProperty.Create(
        nameof(BorderBrush),
        typeof(Brush),
        typeof(VButton)
    );

    public static readonly BindableProperty ButtonBackgroundProperty = BindableProperty.Create(
        nameof(ButtonBackground),
        typeof(Brush),
        typeof(VButton)
    );

    public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(
        nameof(BorderThickness),
        typeof(double),
        typeof(VButton),
        1.0d
    );

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(VButton),
        default
    );

    public static BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize),
        typeof(double),
        typeof(VButton),
        12.0
    );

    public static BindableProperty FontFamilyProperty = BindableProperty.Create(
        nameof(FontFamily),
        typeof(string),
        typeof(VButton),
        string.Empty
    );

    public static BindableProperty ButtonStyleProperty = BindableProperty.Create(
        nameof(ButtonStyle),
        typeof(ButtonStyles),
        typeof(VButton),
        ButtonStyles.Primary,
        propertyChanged: OnButtonStylePropertyChanged
    );

    private static void OnButtonStylePropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue
    )
    {
        (bindable as VButton).SetButtonStyle((ButtonStyles)newValue);
    }

    private void SetButtonStyle(ButtonStyles style)
    {
        var styleResources = "";
        switch (style)
        {
            case ButtonStyles.Light:
                styleResources = "LightVButton";
                break;
            case ButtonStyles.Text:
                styleResources = "TextVButton";
                break;
            case ButtonStyles.Primary:
                styleResources = "PrimaryVButton";
                break;
            case ButtonStyles.Outlined:
                styleResources = "OutlinedVButton";
                break;
            default:
                break;
        }
        this.Style = Application.Current?.Resources[styleResources] as Style;
        if (TextColor == default)
        {
            object textColor = default;
            Application.Current?.Resources.TryGetValue("OnSurface", out textColor);
            TextColor = textColor as Color;
        }
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(VButton)
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(VButton)
    );

    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        nameof(IsBusy),
        typeof(bool),
        typeof(VButton),
        false,
        propertyChanged: OnIsBusyChanged
    );

    static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VButton)?.OnIsBusyChanged();
    }

    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(
        nameof(ProgressColor),
        typeof(Color),
        typeof(VButton)
    );

    public IView ContentSlot { get; set; }

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }
    public Brush ButtonBackground
    {
        get => (Brush)GetValue(ButtonBackgroundProperty);
        set => SetValue(ButtonBackgroundProperty, value);
    }

    public string TitleText
    {
        get { return (string)GetValue(TitleTextProperty); }
        set { SetValue(TitleTextProperty, value); }
    }

    public Brush BorderBrush
    {
        get => (Brush)GetValue(BorderBrushProperty);
        set => SetValue(BorderBrushProperty, value);
    }

    public double BorderThickness
    {
        get => (double)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    [TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }

    public string FontFamily
    {
        get { return (string)GetValue(FontFamilyProperty); }
        set { SetValue(FontFamilyProperty, value); }
    }

    public ButtonStyles ButtonStyle
    {
        get { return (ButtonStyles)GetValue(ButtonStyleProperty); }
        set { SetValue(ButtonStyleProperty, value); }
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

    private ButtonVisualState _visualState;

    public ButtonVisualState ButtonVisualState
    {
        get => _visualState;
        set
        {
            _visualState = value;
            ChangeVisualState();
        }
    }

    public event EventHandler Pressed;
    public event EventHandler Released;
    public event EventHandler Clicked;

    protected async void OnIsBusyChanged()
    {
        if (IsBusy)
        {
            ButtonVisualState = ButtonVisualState.Busy;
        }
        else
        {
            ButtonVisualState = ButtonVisualState.Normal;
        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == IsEnabledProperty.PropertyName)
            UpdateIsEnabled();
    }

    protected override void ChangeVisualState()
    {
        string state;

        switch (ButtonVisualState)
        {
            case ButtonVisualState.Normal:
                state = "Normal";
                break;
            case ButtonVisualState.MouseOver:
                state = "MouseOver";
                break;
            case ButtonVisualState.Pressed:
                state = "Pressed";
                break;
            case ButtonVisualState.Disabled:
                state = "Disabled";
                break;
            case ButtonVisualState.Busy:
                state = "Busy";
                break;
            default:
                state = "Normal";
                break;
        }
        VisualStateManager.GoToState(this, state);
    }

    private void UpdateIsEnabled()
    {
        ButtonVisualState = IsEnabled ? ButtonVisualState.Normal : ButtonVisualState.Disabled;
    }

    private void OnButtonPointerPressed()
    {
        UpdateVisualState(ButtonVisualState.Pressed);
        Pressed?.Invoke(this, EventArgs.Empty);
    }

    private void OnButtonPointerMoved()
    {
        UpdateVisualState(ButtonVisualState.MouseOver);
    }

    private void OnButtonHandlePointerExited()
    {
        UpdateVisualState(ButtonVisualState.Normal);
    }

    private void OnButtonPointerReleased()
    {
        UpdateVisualState(ButtonVisualState.Normal);
        Released?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateVisualState(ButtonVisualState visualState)
    {
        if (!IsEnabled)
            return;

        ButtonVisualState = visualState;
    }

    private void TouchContentView_OnTouchActionInvoked(object sender, TouchActionEventArgs e)
    {
        if (!IsEnabled || IsBusy)
            return;

        switch (e.Type)
        {
            case TouchActionType.Entered:
                this.OnButtonPointerMoved();
                break;
            case TouchActionType.Pressed:
                this.OnButtonPointerPressed();
                break;
            case TouchActionType.Moved:
                break;
            case TouchActionType.Released:

                this.OnButtonPointerReleased();

                Clicked?.Invoke(this, EventArgs.Empty);

                if (Command is not null && Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
                break;
            case TouchActionType.Exited:
                this.OnButtonHandlePointerExited();

                break;
            case TouchActionType.Cancelled:
                break;
            default:
                break;
        }
    }
}
