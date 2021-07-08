using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;
using Newtonsoft.Json.Serialization;

namespace NetCoreLineBotSDK.Models.Message
{
    public class TextMessage : IMessage
    {
        /// <summary>
        /// Message text. You can include the following emoji
        /// </summary>
        /// <param name="text">Message text</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public TextMessage(string text, QuickReply quickReply = null)
        {
            this.Text = text;
            this.QuickReply = quickReply;
        }
        
        public LineMessageType Type => LineMessageType.Text;

        public string Text { get; }

        public QuickReply QuickReply { get; }
    }
}
