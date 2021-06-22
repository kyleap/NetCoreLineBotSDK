using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class FlexMessage : IFlex
    {
        public FlexMessage(dynamic _contents, string altText = "Flex Message")
        {
            Contents = _contents;
            AltText = altText;
            
        }
        public LineMessageType Type => LineMessageType.Flex;

        public string AltText { get; set; }

        public dynamic Contents { get; set; }
    }
}
