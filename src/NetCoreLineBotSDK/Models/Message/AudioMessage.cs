using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class AudioMessage : IMessage
    {
        public LineMessageType Type => LineMessageType.audio;
        public string OriginalContentUrl { get; set; }
        public int Duration { get; set; } = 60000;
    }
}
