namespace VControl.Controls;

public partial class VEditor : ContentView
{
    public static readonly BindableProperty EditorTextProperty = BindableProperty.Create(
        nameof(EditorText),
        typeof(string),
        typeof(VEditor),
        string.Empty,
        //propertyChanged: OnEditorTextPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty EditorPlaceholderProperty = BindableProperty.Create(
        nameof(EditorPlaceholder),
        typeof(string),
        typeof(VEditor),
        "Enter content here.",
        //propertyChanged: OnEditorTextPropertyChanged,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty EditorKeyboardProperty = BindableProperty.Create(
        nameof(EditorKeyboard),
        typeof(Keyboard),
        typeof(VEditor),
        Keyboard.Default,
        //propertyChanged: OnEditorWidthPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty EditorMaxLengthProperty = BindableProperty.Create(
        nameof(EditorMaxLength),
        typeof(int?),
        typeof(VEditor),
        default,
        defaultBindingMode: BindingMode.TwoWay
    );

    public static readonly BindableProperty EditorIsReadOnlyProperty = BindableProperty.Create(
        nameof(EditorIsReadOnly),
        typeof(bool),
        typeof(VEditor),
        false,
        defaultBindingMode: BindingMode.TwoWay
    );

    public string EditorText
    {
        get => (string)GetValue(EditorTextProperty);
        set => SetValue(EditorTextProperty, value);
    }

    public string EditorPlaceholder
    {
        get => (string)GetValue(EditorPlaceholderProperty);
        set => SetValue(EditorPlaceholderProperty, value);
    }

    public Keyboard EditorKeyboard
    {
        get => (Keyboard)GetValue(EditorKeyboardProperty);
        set => SetValue(EditorKeyboardProperty, value);
    }

    public int? EditorMaxLength
    {
        get => (int?)GetValue(EditorMaxLengthProperty);
        set => SetValue(EditorMaxLengthProperty, value);
    }

    public bool EditorIsReadOnly
    {
        get => (bool)GetValue(EditorIsReadOnlyProperty);
        set => SetValue(EditorIsReadOnlyProperty, value);
    }

    public VEditor()
    {
        InitializeComponent();
    }
}
