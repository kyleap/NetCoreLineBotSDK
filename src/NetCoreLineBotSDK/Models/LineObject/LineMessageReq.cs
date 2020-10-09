using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models
{
    public class LineMessageReq
    {
        public string ReplyToken { get; set; }
        public List<IMessage> Messages { get; set; } = new List<IMessage>();
    }
}
