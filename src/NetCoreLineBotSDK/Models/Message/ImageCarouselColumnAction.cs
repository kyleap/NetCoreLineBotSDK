using NetCoreLineBotSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageCarouselColumnAction
    {
        /// <summary>
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// JPEG or PNG
        /// </summary>
        public string ThumbnailImageUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public ColumnDefaultaction DefaultAction { get; set; }
        public IAction Action { get; set; }
    }
}
