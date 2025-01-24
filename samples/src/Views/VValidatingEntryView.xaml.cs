using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Controls.Validations;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VValidatingEntryView : ContentPageBase<VValidatingEntryViewModel>
{

    public VValidatingEntryView(VValidatingEntryViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

    }

}