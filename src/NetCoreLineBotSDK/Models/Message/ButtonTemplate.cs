using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ButtonTemplate : ITemplate
    {
        public ButtonTemplate(string text, List<IAction> actions, string thumbnailImageUrl = null)
        {
            Text = text;
            Actions = actions;
            ThumbnailImageUrl = thumbnailImageUrl;
        }
        public string Type => "buttons";
        /// <summary>
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// JPEG or PNG
        /// </summary>
        public string ThumbnailImageUrl { get; set; }
        public ImageAspectRatioType ImageAspectRatio { get; set; } = ImageAspectRatioType.rectangle;
        public ImageSizeType ImageSize { get; set; } = ImageSizeType.cover;
        public string ImageBackgroundColor { get; set; } = "#FFFFFF";
        public string Title { get; set; }
        public string Text { get; set; }
        public ColumnDefaultaction DefaultAction { get; set; }
        public List<IAction> Actions { get; set; }
    }
}
