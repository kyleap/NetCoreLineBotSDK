using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    /// <summary>
    /// Api reference: https://developers.line.biz/media/messaging-api/sticker_list.pdf
    /// </summary>
    public class StickerMessage : IMessage
    {
        public LineMessageType Type => LineMessageType.Sticker;
        public string PackageId { get; set; }
        public string StickerId { get; set; }
    }
}
