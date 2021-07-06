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
        /// <summary>
        /// Sticker message
        /// </summary>
        /// <param name="packageId">Package ID for a set of stickers. For information on package IDs</param>
        /// <param name="stickerId">Sticker ID. For a list of sticker IDs for stickers that can be sent with the Messaging API</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public StickerMessage(int packageId, int stickerId, QuickReply quickReply = null)
        {
            PackageId = packageId.ToString();
            StickerId = stickerId.ToString();
            QuickReply = quickReply;
        }
        public LineMessageType Type => LineMessageType.Sticker;
        public string PackageId { get; }
        public string StickerId { get; }

        public QuickReply QuickReply { get; }
    }
}
