using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class StyleSamplesPage : ContentPageBase<StyleSamplesViewModel>
{
    public StyleSamplesPage(StyleSamplesViewModel viewModel): base(viewModel)
    {        
        InitializeComponent();
    }

   

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

}
