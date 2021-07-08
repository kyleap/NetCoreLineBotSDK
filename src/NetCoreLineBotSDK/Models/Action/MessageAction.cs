using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class MessageAction : IAction
    {
        public MessageAction(string text, string label = null)
        {
            Text = text;
            Label = string.IsNullOrEmpty(label) ? text : label;
        }
        public string Text { get; set; }
        public ActionType Type => ActionType.Message;
        public string Label { get; set; }

        public ActionArea area { get; set; }
    }

}
