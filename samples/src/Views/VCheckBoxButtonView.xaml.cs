using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VCheckBoxButtonView : ContentPageBase<VCheckBoxButtonViewModel>
{
    public VCheckBoxButtonView(VCheckBoxButtonViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}