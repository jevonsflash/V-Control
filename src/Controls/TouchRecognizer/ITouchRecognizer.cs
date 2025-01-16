using VControl.Controls;
using Microsoft.Maui.Platform;

namespace VControl.Controls
{
    public interface ITouchRecognizer : IDisposable
    {
        event EventHandler<TouchActionEventArgs> OnTouchActionInvoked;
        void Dispose();
    }
}
