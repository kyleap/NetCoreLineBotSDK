namespace NetCoreLineBotSDK.Models.Message
{
    public class BaseMessage
    {
        public MessageSender Sender { get; set; }
        public QuickReply QuickReply { get; set; }    
    }
}