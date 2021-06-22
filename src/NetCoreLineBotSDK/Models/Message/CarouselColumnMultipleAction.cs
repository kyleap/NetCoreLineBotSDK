using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class CarouselColumnMultipleAction
    {
        /// <summary>
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// JPEG or PNG
        /// </summary>
        public string ThumbnailImageUrl { get; set; }
        public ImageAspectRatioType ImageAspectRatio { get; set; } = ImageAspectRatioType.Rectangle;
        public ImageSizeType ImageSize { get; set; } = ImageSizeType.Cover;
        public string ImageBackgroundColor { get; set; } = "#000000";
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public ColumnDefaultaction DefaultAction { get; set; }
        public List<IAction> Actions { get; set; }
    }
}
