using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class AudioMessage : IMessage
    {
        /// <summary>
        /// Audio message
        /// </summary>
        /// <param name="originalContentUrl">URL of audio file (Max character limit: 1000)</param>
        public AudioMessage(string originalContentUrl)
        {
            this.OriginalContentUrl = originalContentUrl;
        }

        public LineMessageType Type => LineMessageType.Audio;
        public string OriginalContentUrl { get; set; }
        public int Duration { get; set; } = 60000;
    }
}
