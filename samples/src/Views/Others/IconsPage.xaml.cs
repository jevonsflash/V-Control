using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class IconsPage : ContentPageBase<IconsPageViewModel>
{
    public IconsPage(IconsPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

}
