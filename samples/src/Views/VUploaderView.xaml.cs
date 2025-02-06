using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;



public partial class VUploaderView : ContentPageBase<VUploaderViewModel>
{
    public VUploaderView(VUploaderViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}