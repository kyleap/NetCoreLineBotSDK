using System.Collections.Generic;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.LineObject
{
    public class LineMessagePushReq
    {
        public string To { get; set; }
        public List<IRequestMessage> Messages { get; set; } = new List<IRequestMessage>();
    }
}