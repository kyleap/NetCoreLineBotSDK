using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class PostbackAction : IAction
    {
        public PostbackAction(string data, string label = "")
        {
            Data = data;
            Label = string.IsNullOrEmpty(label) ? data : label;
        }

        public PostbackAction(string text, string data, string label = "")
        {
            Text = text;
            Data = data;
            Label = string.IsNullOrEmpty(label) ? text : label;
        }

        public string Data { get; set; }
        public string Text { get; set; }
        public ActionType Type => ActionType.postback;
        public string Label { get; set; }
    }
}
