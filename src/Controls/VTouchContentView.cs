using System.Diagnostics;
using VControl.Controls;

namespace VControl.Controls
{
    public class VTouchContentView : ContentView
    {
        private ITouchRecognizer touchRecognizer;

        public event EventHandler<TouchActionEventArgs> OnTouchActionInvoked;



        public VTouchContentView()
        {
            HandlerChanged += TouchContentView_HandlerChanged;
            HandlerChanging += TouchContentView_HandlerChanging;
        }


        private void TouchContentView_HandlerChanged(object sender, EventArgs e)
        {

            var handler = Handler;
            if (handler != null)
            {
#if ANDROID
                touchRecognizer = new TouchRecognizer_Android(handler.PlatformView as Android.Views.View);
                touchRecognizer.OnTouchActionInvoked += TouchRecognizer_OnTouchActionInvoked;

#endif

#if IOS|| MACCATALYST
                touchRecognizer = new TouchRecognizer_iOS(handler.PlatformView as UIKit.UIView);
                touchRecognizer.OnTouchActionInvoked += TouchRecognizer_OnTouchActionInvoked;

                (handler.PlatformView as UIKit.UIView).UserInteractionEnabled = true;
                (handler.PlatformView as UIKit.UIView).AddGestureRecognizer(touchRecognizer as TouchRecognizer_iOS);
#endif
            }

        }

        private void TouchContentView_HandlerChanging(object sender, HandlerChangingEventArgs e)
        {


            if (e.OldHandler != null)
            {
                var handler = e.OldHandler;

#if ANDROID
                touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked;

#endif

#if IOS|| MACCATALYST
                touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked;

                (handler.PlatformView as UIKit.UIView).UserInteractionEnabled = false;
                (handler.PlatformView as UIKit.UIView).RemoveGestureRecognizer(touchRecognizer as TouchRecognizer_iOS);
#endif


            }
        }

        private void TouchRecognizer_OnTouchActionInvoked(object sender, TouchActionEventArgs e)
        {
            OnTouchActionInvoked?.Invoke(this, e);
        }

    }
}
