using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageCarouselTemplate : ITemplate
    {
        public string Type => "image_carousel";

        public List<ImageCarouselColumnAction> Columns { get; set; }
    }
}
