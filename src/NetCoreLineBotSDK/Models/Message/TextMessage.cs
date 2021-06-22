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
        public string Text { get; set; }

        public LineMessageType Type => LineMessageType.Text;

        public QuickReply QuickReply { get; set; }
    }
}
