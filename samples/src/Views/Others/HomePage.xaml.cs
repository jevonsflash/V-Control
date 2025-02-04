using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class HomePage : ContentPageBase<HomeViewModel>
{
    public HomePage(HomeViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) { }

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        var progress = Math.Min(65, e.ScrollY) / 65;
        this.MainTopAppBar.Progress = progress;
    }
}
