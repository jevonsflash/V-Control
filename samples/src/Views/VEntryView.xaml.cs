using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls.Compatibility;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VEntryView : ContentPageBase<VEntryViewModel>
{
    public VEntryView(VEntryViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
