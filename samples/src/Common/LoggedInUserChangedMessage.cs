using CommunityToolkit.Mvvm.Messaging.Messages;

namespace VControl.Samples.Common
{
    public class LoggedInUserChangedMessage : ValueChangedMessage<string>
    {
        public LoggedInUserChangedMessage(string user) : base(user)
        {
        }
    }
}
