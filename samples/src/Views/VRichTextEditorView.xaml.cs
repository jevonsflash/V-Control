using System.Collections.ObjectModel;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class VRichTextEditorView : ContentPageBase<VRichTextEditorViewModel>
{
    public VRichTextEditorView(VRichTextEditorViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}

