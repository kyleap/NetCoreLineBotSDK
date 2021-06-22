using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;

namespace NetCoreLineBotSDK.Models.LineObject
{

    public class LineEvent
    {
        public WebhookEventType type { get; set; }
        public string replyToken { get; set; }
        public WebhookEventSource source { get; set; }
        public long timestamp { get; set; }
        public string mode { get; set; }
        public LineMessage message { get; set; }
        public VideoPlayComplete videoPlayComplete { get; set; }
        public Beacon beacon { get; set; }
        public Link link { get; set;}
        public PostBack postback { get; set; }
    }
}
