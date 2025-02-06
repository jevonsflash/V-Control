using System.Collections.ObjectModel;
using System.ComponentModel;
using VControl.Samples.Models;
using VControl.Samples.Services.Navigation;

namespace VControl.Samples.ViewModels;

public partial class VRichTextEditorViewModel : ViewModelBase
{
    public VRichTextEditorViewModel(INavigationService navService)
        : base(navService)
    {
        this.PageTitle = "VRichTextEditorView Samples";
    }

    [ObservableProperty]
    private string _content;

    [ObservableProperty]
    private string _placeHolder;

    [ObservableProperty]
    private string _htmlContent;
}
