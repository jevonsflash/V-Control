using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VNumberEntryView : ContentPageBase<VNumberEntryViewModel>
{
    public VNumberEntryView(VNumberEntryViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
