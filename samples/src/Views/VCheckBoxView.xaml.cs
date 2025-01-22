
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;


public partial class VCheckBoxView : ContentPageBase<VCheckBoxViewModel>
{

    public VCheckBoxView(VCheckBoxViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

    }

}
