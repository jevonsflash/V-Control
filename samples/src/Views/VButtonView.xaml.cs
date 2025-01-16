using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VControl.Samples.ViewModels;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VButtonView : ContentPageBase<VButtonViewModel>
{

    public VButtonView(VButtonViewModel viewModel): base(viewModel)
    {
        InitializeComponent();
   

    }

  

   
}