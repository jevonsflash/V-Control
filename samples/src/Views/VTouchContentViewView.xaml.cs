using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VTouchContentViewView : ContentPageBase<VTouchContentViewViewModel>
{
    public VTouchContentViewView(VTouchContentViewViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }

    private void TouchContentView_OnTouchActionInvoked(
        object sender,
        Controls.TouchActionEventArgs e
    )
    {
        var msg = e.Type + " is Invoked, position:" + e.Location;
        (BindingContext as VTouchContentViewViewModel).DebugMessages.Insert(0, msg);
    }
}
