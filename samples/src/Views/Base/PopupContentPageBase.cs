namespace VControl.Samples.Views.Base;

public abstract class PopupContentPageBase<TViewModel> : PopupContentPageBase
    where TViewModel : ViewModelBase
{
    public PopupContentPageBase(TViewModel viewModel)
        : base(viewModel)
    {
        this.Opened += PopupBase_Opened;
    }

    public abstract void PopupBase_Opened(
        object sender,
        CommunityToolkit.Maui.Core.PopupOpenedEventArgs e
    );

    public new TViewModel BindingContext => (TViewModel)base.BindingContext;
}

public abstract class PopupContentPageBase : CommunityToolkit.Maui.Views.Popup
{
    private readonly IDeviceDisplay deviceDisplay;

    public PopupContentPageBase(object? viewModel = null)
    {
        BindingContext = viewModel;
        NavigationPage.SetBackButtonTitle(this, string.Empty);
        this.deviceDisplay = DeviceDisplay.Current;
        this.deviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        this.Opened += PopupContentPageBase_Opened;
    }

    private void PopupContentPageBase_Opened(
        object sender,
        CommunityToolkit.Maui.Core.PopupOpenedEventArgs e
    )
    {
        var displayInfo = this.deviceDisplay.MainDisplayInfo;
        SetSize(displayInfo);
    }

    private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        var displayInfo = e.DisplayInfo;
        // 新的宽度和高度
        SetSize(displayInfo);
    }

    protected virtual void SetSize(DisplayInfo displayInfo)
    {
        var newWidth = displayInfo.Width;
        var newHeight = displayInfo.Height * VerticalHRatio;

        var d = displayInfo.Density;
        PopupSize = new Size(newWidth / d, newHeight / d);
        this.Size = PopupSize;
    }

    public Size PopupSize { get; set; }
    public double VerticalHRatio { get; set; } = 0.8;
}
