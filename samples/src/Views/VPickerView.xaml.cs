using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;


public partial class VPickerView : ContentPageBase<VPickerViewModel>
{
    public VPickerView(VPickerViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}