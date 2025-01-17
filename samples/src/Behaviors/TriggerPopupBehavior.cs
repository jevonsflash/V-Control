using VControl.Samples.Common;

namespace VControl.Samples.Behaviors
{
    public class TriggerPopupBehavior : Behavior<ContentPage>
    {
        public bool PopupLoading { get; private set; }

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Appearing += OnPageAppearing;
            bindable.Disappearing += OnPageDisappearing;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Appearing -= OnPageAppearing;
            bindable.Disappearing -= OnPageDisappearing;
        }

        private async void OnPageAppearing(object sender, EventArgs e)
        {
            (sender as ITriggerPopupPage)?.Triggerpopup();
        }

        private async void OnPageDisappearing(object sender, EventArgs e)
        {
            (sender as ITriggerPopupPage)?.Dismisspopup();
        }
    }
}
