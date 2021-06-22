using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class VideoMessage : IMessage
    {
        public LineMessageType Type => LineMessageType.Video;
        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public string TrackingId { get; set; }
    }
    
}
