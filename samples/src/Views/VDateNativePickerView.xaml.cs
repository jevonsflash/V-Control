using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VDateNativePickerView : ContentPageBase<VDateNativePickerViewModel>
{
    public VDateNativePickerView(VDateNativePickerViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}