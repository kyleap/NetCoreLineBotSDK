using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class FlexMessage : IMessage
    {
        public LineMessageType Type => LineMessageType.flex;

        public string AltText => "Flex Message";

        public dynamic Contents { get; set; }
    }
}
