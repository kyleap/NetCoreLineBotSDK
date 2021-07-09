using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class LocationMessage : BaseMessage, IMessage
    {
        /// <summary>
        /// Location Message
        /// </summary>
        /// <param name="title">Max character limit: 100</param>
        /// <param name="address">Max character limit: 100</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public LocationMessage(string title, string address, decimal latitude, decimal longitude)
        {
            Title = title;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public LineMessageType Type => LineMessageType.Location;
        public string Title { get;}
        public string Address { get;}
        public decimal Latitude { get;}
        public decimal Longitude { get;}
    }
}
