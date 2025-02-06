using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;


public partial class VIndicatorView : ContentPageBase<VIndicatorViewModel>
{
    public VIndicatorView(VIndicatorViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}