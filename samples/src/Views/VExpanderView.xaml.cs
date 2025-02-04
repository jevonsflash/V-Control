using System.Collections;
using System.Windows.Input;
using VControl.Controls.VExpandable;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VExpanderView : ContentPageBase<VExpanderViewModel>
{
    public VExpanderView(VExpanderViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
