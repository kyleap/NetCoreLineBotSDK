using NetCoreLineBotSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageCarouselColumnAction
    {
        /// <summary>
        /// ImageCarouselColumnAction
        /// </summary>
        /// <param name="imageUrl">Image URL (Max character limit: 1,000)</param>
        /// <param name="action">Action when image is tapped</param>
        public ImageCarouselColumnAction(string imageUrl, IAction action)
        {
            this.ImageUrl = imageUrl;
            this.Action = action;
        }

        /// <summary>
        /// Max width: 1024px
        /// Max file size: 1 MB
        /// JPEG or PNG
        /// </summary>
        public string ThumbnailImageUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; }
        public ColumnDefaultaction DefaultAction { get; set; }
        public IAction Action { get; }
    }
}
