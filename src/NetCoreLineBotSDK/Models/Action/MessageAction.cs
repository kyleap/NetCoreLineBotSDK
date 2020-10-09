using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class MessageAction : IAction
    {
        /// <summary>
        /// MessageAction
        /// </summary>
        /// <param name="text">文字訊息</param>
        /// <param name="label">顯示訊息(options)</param>
        public MessageAction(string text, string label = "")
        {
            Text = text;
            Label = string.IsNullOrEmpty(label) ? text : label;
        }
        public string Text { get; set; }
        public ActionType Type => ActionType.message;
        public string Label { get; set; }
    }

}
