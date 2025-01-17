namespace VControl.Controls;

public partial class VIndicator : ContentView
{
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(
        nameof(ProgressColor),
        typeof(Color),
        typeof(VIndicator)
    );

    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
        nameof(IsBusy),
        typeof(bool),
        typeof(VIndicator),
        false,
        propertyChanged: OnIsBusyChanged
    );

    static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as VIndicator)?.OnIsBusyChanged();
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

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public VIndicator()
    {
        InitializeComponent();
    }
}
