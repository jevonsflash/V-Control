namespace VControl.Controls.VExpandable
{
    public class ExpanderAnimation : IExpanderAnimation
    {
        protected uint AnimationLength { get; } = 150;

        public async Task OnCollapse(View view)
        {
            await view.ScaleYTo(0, AnimationLength, Easing.CubicOut);
        }

        public async Task OnExpand(View view)
        {
            await view.ScaleYTo(1, AnimationLength, Easing.CubicIn);
        }
    }
}
