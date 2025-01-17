namespace VControl.Controls
{
    public interface ITouchRecognizer : IDisposable
    {
        event EventHandler<TouchActionEventArgs> OnTouchActionInvoked;

        void Dispose();
    }
}
