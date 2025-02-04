using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VMenuCellView : ContentPageBase<VMenuCellViewModel>
{
    public VMenuCellView(VMenuCellViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
