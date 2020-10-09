using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Models.LineObject;

namespace NetCoreLineBotSDK.Models
{
    public class WebhookEvent
    {
        public LineEvent[] events { get; set; }
        public string destination { get; set; }
    }
}
