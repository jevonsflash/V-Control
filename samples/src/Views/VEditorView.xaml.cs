using System.Collections.ObjectModel;
using System.Windows.Input;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VEditorView : ContentPageBase<VEditorViewModel>
{

    public VEditorView(VEditorViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

    }

}