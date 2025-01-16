using VControl.Samples.ViewModels;
using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class HomePage : ContentPageBase<HomeViewModel>
{
    public HomePage(HomeViewModel viewModel): base(viewModel)
    {        
        InitializeComponent();
    }

   

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

}
