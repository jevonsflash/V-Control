using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class ColorsPage : ContentPageBase<ColorsPageViewModel>
{
    public ColorsPage(ColorsPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

}
