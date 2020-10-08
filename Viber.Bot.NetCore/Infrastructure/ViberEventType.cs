namespace Viber.Bot.NetCore.Infrastructure
{
    public static class ViberEventType
    {
        public const string Delivered = "delivered";
        public const string Seen = "seen";
        public const string Failed = "failed";
        public const string Subscribed = "subscribed";
        public const string Unsubscribed = "unsubscribed";
        public const string ConversationStarted = "conversation_started";
        public const string Message = "message";
        public const string Webhook = "webhook";
        public const string Action = "action";
    }
}