using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class AudioMessage :BaseMessage, IMessage
    {
        /// <summary>
        /// Audio message
        /// </summary>
        /// <param name="originalContentUrl">URL of audio file (Max character limit: 1000)</param>
        /// <param name="duration">URL of audio file (Max character limit: 1000)</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public AudioMessage(string originalContentUrl, int duration = 60000)
        {
            this.OriginalContentUrl = originalContentUrl;
            Duration = duration;
        }

        public LineMessageType Type => LineMessageType.Audio;
        public string OriginalContentUrl { get;}
        public int Duration { get;}
    }
}
