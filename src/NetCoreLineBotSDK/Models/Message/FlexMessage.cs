using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;
using Newtonsoft.Json;

namespace NetCoreLineBotSDK.Models.Message
{
    public class FlexMessage : IFlex
    {
        /// <summary>
        /// Flex Message
        /// https://developers.line.biz/flex-simulator/
        /// </summary>
        /// <param name="json"></param>
        /// <param name="altText"></param>
        public FlexMessage(string json, string altText = "Flex Message")
        {
            Contents = JsonConvert.DeserializeObject(json);
            AltText = altText;
        }
        public LineMessageType Type => LineMessageType.Flex;

        public string AltText { get; }

        public dynamic Contents { get; set; }
    }
}
