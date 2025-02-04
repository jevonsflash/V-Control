using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VTopAppBarView : ContentPageBase<VTopAppBarViewModel>
{
    public VTopAppBarView(VTopAppBarViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
