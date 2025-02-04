using System.Collections;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VTimeLineView : ContentPageBase<VTimeLineViewModel>
{
    public VTimeLineView(VTimeLineViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
