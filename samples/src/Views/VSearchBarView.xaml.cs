using System.Collections;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VSearchBarView : ContentPageBase<VSearchBarViewModel>
{
    public VSearchBarView(VSearchBarViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
