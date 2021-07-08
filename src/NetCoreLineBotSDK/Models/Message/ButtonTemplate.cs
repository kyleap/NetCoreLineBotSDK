using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ButtonTemplate : ITemplate
    {
        /// <summary>
        /// Button Template
        /// </summary>
        /// <param name="text"></param>
        /// <param name="actions"></param>
        /// <param name="thumbnailImageUrl">Image URL (Max character limit: 1,000)</param>
        public ButtonTemplate(string text, List<IAction> actions, string thumbnailImageUrl = null, QuickReply quickReply = null)
        {
            Text = text;
            Actions = actions;
            ThumbnailImageUrl = thumbnailImageUrl;
            QuickReply = quickReply;
        }

        public string Type => "buttons";

        public string ThumbnailImageUrl { get; set; }
        public ImageAspectRatioType ImageAspectRatio { get; set; } = ImageAspectRatioType.Rectangle;
        public ImageSizeType ImageSize { get; set; } = ImageSizeType.Cover;
        public string ImageBackgroundColor { get; set; } = "#FFFFFF";
        public string Title { get; set; }
        public string Text { get; set; }
        public ColumnDefaultaction DefaultAction { get; set; }
        public List<IAction> Actions { get; set; }
        public QuickReply QuickReply { get; set; }
    }
}
