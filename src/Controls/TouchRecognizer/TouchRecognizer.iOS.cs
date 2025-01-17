using Foundation;
using UIKit;

namespace VControl.Controls
{
    public class TouchRecognizer_iOS : UIGestureRecognizer, IDisposable, ITouchRecognizer
    {
        internal UIView iosView;

        public TouchRecognizer_iOS(UIView view)
        {
            this.iosView = view;
        }

        public event EventHandler<TouchActionEventArgs> OnTouchActionInvoked;

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.Handle.ToInt64();
                InvokeTouchActionEvent(id, TouchActionType.Pressed, touch, true);
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.Handle.ToInt64();

                InvokeTouchActionEvent(id, TouchActionType.Moved, touch, true);
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.Handle.ToInt64();

                InvokeTouchActionEvent(id, TouchActionType.Released, touch, false);
            }
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.Handle.ToInt64();

                InvokeTouchActionEvent(id, TouchActionType.Cancelled, touch, false);
            }
        }

        internal void InvokeTouchActionEvent(
            long id,
            TouchActionType actionType,
            UITouch touch,
            bool isInContact
        )
        {
            var cgPoint = touch.LocationInView(this.View);
            var xfPoint = new Point(cgPoint.X, cgPoint.Y);
            OnTouchActionInvoked?.Invoke(
                this,
                new TouchActionEventArgs(id, actionType, xfPoint, isInContact)
            );
        }
    }
}
