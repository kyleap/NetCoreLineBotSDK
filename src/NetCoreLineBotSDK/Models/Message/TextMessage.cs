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
        public TextMessage()
        {

        }

        /// <summary>
        /// Message text. You can include the following emoji
        /// e.g \uDBC0\uDC84 LINE original emoji
        /// https://developers.line.biz/media/messaging-api/emoji-list.pdf
        /// </summary>
        /// <param name="text"></param>
        /// <param name="quickReply"></param>
        public TextMessage(string text, QuickReply quickReply = null)
        {
            this.Text = text;
            this.QuickReply = quickReply;
        }
        public string Text { get; set; }

        public LineMessageType Type => LineMessageType.Text;

        public QuickReply QuickReply { get; set; }
    }
}
