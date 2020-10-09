using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;

namespace NetCoreLineBotSDK.Models
{
    public class LineMessage
    {
        public LineMessageType Type { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
