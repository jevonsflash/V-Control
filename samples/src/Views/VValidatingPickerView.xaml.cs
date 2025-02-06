using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Controls.Validations;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;


public partial class VValidatingPickerView : ContentPageBase<VValidatingPickerViewModel>
{
    public VValidatingPickerView(VValidatingPickerViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
