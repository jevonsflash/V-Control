using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VButtonView : ContentPageBase<VButtonViewModel>
{
    public VButtonView(VButtonViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
