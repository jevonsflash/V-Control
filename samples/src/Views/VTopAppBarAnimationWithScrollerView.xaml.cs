using VControl.Samples.Views.Base;

namespace VControl.Samples.Views;

public partial class AnimationWithScrollerView : ContentPageBase<AnimationWithScrollerViewModel>
{

    public AnimationWithScrollerView(AnimationWithScrollerViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        var progress = Math.Min(65, e.ScrollY) / 65;
        this.MainTopAppBar.Progress = progress;
    }
}
