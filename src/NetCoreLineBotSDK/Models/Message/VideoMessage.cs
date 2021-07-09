using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class VideoMessage : BaseMessage, IMessage
    {
        /// <summary>
        /// Video Message
        /// </summary>
        /// <param name="originalContentUrl">URL of video file (Max character limit: 1000)</param>
        /// <param name="previewImageUrl">URL of preview image (Max character limit: 1000)</param>
        /// <param name="trackingId">ID used to identify the video when Video viewing complete event occurs. If you send a video message with trackingId added, the video viewing complete event occurs when the user finishes watching the video.</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public VideoMessage(string originalContentUrl, string previewImageUrl,string trackingId = null)
        {
            OriginalContentUrl = originalContentUrl;
            PreviewImageUrl = previewImageUrl;
            TrackingId = trackingId;
        }
        public LineMessageType Type => LineMessageType.Video;
        public string OriginalContentUrl { get; }
        public string PreviewImageUrl { get; }
        public string TrackingId { get;}
    }

}
