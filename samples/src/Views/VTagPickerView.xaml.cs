using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using VControl.Controls;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VTagPickerView : ContentPageBase<VTagPickerViewModel>
{
    public VTagPickerView(VTagPickerViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
