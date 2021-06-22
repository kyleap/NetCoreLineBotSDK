using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageMessage : IMessage
    {
        public LineMessageType Type => LineMessageType.Image;
        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
    }
}
