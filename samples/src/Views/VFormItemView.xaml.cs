using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;



public partial class VFormItemView : ContentPageBase<VFormItemViewModel>
{
    public VFormItemView(VFormItemViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}