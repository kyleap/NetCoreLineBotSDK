using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class VideoMessage : IMessage
    {
        /// <summary>
        /// Video Message
        /// </summary>
        /// <param name="originalContentUrl">URL of video file (Max character limit: 1000)</param>
        /// <param name="previewImageUrl">URL of preview image (Max character limit: 1000)</param>
        public VideoMessage(string originalContentUrl, string previewImageUrl)
        {
            this.OriginalContentUrl = originalContentUrl;
            this.PreviewImageUrl = previewImageUrl;
        }
        public LineMessageType Type => LineMessageType.Video;
        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public string TrackingId { get; set; }
    }
    
}
