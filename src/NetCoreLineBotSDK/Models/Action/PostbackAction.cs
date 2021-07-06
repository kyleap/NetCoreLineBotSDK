using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class PostbackAction : IAction
    {
        public PostbackAction(string text, string data, string label = null)
        {
            Text = text;
            Data = data;
            Label = string.IsNullOrEmpty(label) ? text : label;
        }

        public string Data { get; }
        public string Text { get; }
        public ActionType Type => ActionType.Postback;
        public string Label { get;}

        public ActionArea area { get; set; }
    }
}
