using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ButtonTemplate : BaseMessage, ITemplate
    {
        /// <summary>
        /// Button Template
        /// </summary>
        /// <param name="text"></param>
        /// <param name="actions"></param>
        /// <param name="thumbnailImageUrl">Image URL (Max character limit: 1,000)</param>
        public ButtonTemplate(string text, List<IAction> actions, string thumbnailImageUrl = null)
        {
            Text = text;
            Actions = actions;
            ThumbnailImageUrl = thumbnailImageUrl;
        }

        public string Type => "buttons";
        
        public string Title { get; set; }
        public string Text { get; set; }
        public string ThumbnailImageUrl { get; set; }

        public ImageAspectRatioType ImageAspectRatio { get; set; } = ImageAspectRatioType.Rectangle;
        
        public ImageSizeType ImageSize { get; set; } = ImageSizeType.Cover;
        
        public string ImageBackgroundColor { get; set; } = "#FFFFFF";
        
        public ColumnDefaultaction DefaultAction { get; set; }
        public List<IAction> Actions { get; set; }
    }
}
