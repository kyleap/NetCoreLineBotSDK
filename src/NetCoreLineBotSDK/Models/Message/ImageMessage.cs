using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageMessage : IMessage
    {
        /// <summary>
        /// Image Message
        /// </summary>
        /// <param name="originalContentUrl">Image URL (Max character limit: 1000)</param>
        /// <param name="previewImageUrl">Preview image URL (Max character limit: 1000)</param>
        public ImageMessage(string originalContentUrl, string previewImageUrl)
        {
            this.OriginalContentUrl = originalContentUrl;
            this.PreviewImageUrl = previewImageUrl;
        }
        public LineMessageType Type => LineMessageType.Image;
        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
    }
}
