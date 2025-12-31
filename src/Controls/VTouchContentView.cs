namespace VControl.Controls
{
    public class VTouchContentView : ContentView
    {
        private ITouchRecognizer touchRecognizer;

        public VTouchContentView()
        {
            HandlerChanged += TouchContentView_HandlerChanged;
            HandlerChanging += TouchContentView_HandlerChanging;
        }

        public event EventHandler<TouchActionEventArgs> OnTouchActionInvoked;

        private void TouchContentView_HandlerChanged(object sender, EventArgs e)
        {
            var handler = Handler;
            if (handler == null)
                return;

#if ANDROID
            var platformView = handler.PlatformView as Android.Views.View;
            if (platformView == null)
                return;

            // cleanup any existing recognizer
            if (touchRecognizer != null)
            {
                try { touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked; } catch { }
                try { touchRecognizer.Dispose(); } catch { }
                touchRecognizer = null;
            }

            touchRecognizer = new TouchRecognizer_Android(platformView);
            touchRecognizer.OnTouchActionInvoked += TouchRecognizer_OnTouchActionInvoked;
#endif

#if IOS|| MACCATALYST
            var uiView = handler.PlatformView as UIKit.UIView;
            if (uiView == null)
                return;

            if (touchRecognizer != null)
            {
                try { touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked; } catch { }
                try { touchRecognizer.Dispose(); } catch { }
                touchRecognizer = null;
            }

            touchRecognizer = new TouchRecognizer_iOS(uiView);
            touchRecognizer.OnTouchActionInvoked += TouchRecognizer_OnTouchActionInvoked;

            uiView.UserInteractionEnabled = true;
            try { uiView.AddGestureRecognizer(touchRecognizer as TouchRecognizer_iOS); } catch { }
#endif
        }

        private void TouchContentView_HandlerChanging(object sender, HandlerChangingEventArgs e)
        {
            if (e.OldHandler != null)
            {
#if ANDROID
                if (touchRecognizer != null)
                {
                    try { touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked; } catch { }
                    try { touchRecognizer.Dispose(); } catch { }
                    touchRecognizer = null;
                }
#endif

#if IOS|| MACCATALYST
                if (touchRecognizer != null)
                {
                    try { touchRecognizer.OnTouchActionInvoked -= TouchRecognizer_OnTouchActionInvoked; } catch { }

                    var uiView = e.OldHandler.PlatformView as UIKit.UIView;
                    var gestureRecognizer = touchRecognizer as TouchRecognizer_iOS;
                    if (uiView != null && gestureRecognizer != null)
                    {
                        try { uiView.UserInteractionEnabled = false; } catch { }
                        try { uiView.RemoveGestureRecognizer(gestureRecognizer); } catch { }
                    }

                    try { touchRecognizer.Dispose(); } catch { }
                    touchRecognizer = null;
                }
#endif
            }
        }

        private void TouchRecognizer_OnTouchActionInvoked(object sender, TouchActionEventArgs e)
        {
            OnTouchActionInvoked?.Invoke(this, e);
        }
    }
}
