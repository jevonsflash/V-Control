using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VRadioButtonView : ContentPageBase<VRadioButtonViewModel>
{
    public VRadioButtonView(VRadioButtonViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
