using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ConfirmTemplate : ITemplate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ConfirmTemplate(string text = "您確定嗎?", List<IAction> actions = null)
        {
            Text = text;
            if (actions == null)
            {
                Actions = new List<IAction>()
                {
                    new MessageAction("Yes", "是"),
                    new MessageAction("No", "否")
                };
            }
        }

        public string Type => "confirm";

        public string Text { get; set; }

        public List<IAction> Actions { get; set; }
    }
}
