﻿using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageCarouselTemplate : ITemplate
    {
        /// <summary>
        /// Image Carousel Template
        /// </summary>
        /// <param name="columns"></param>
        public ImageCarouselTemplate(List<ImageCarouselColumnAction> columns)
        {
            Columns = columns;
        }
        public string Type => "image_carousel";

        public List<ImageCarouselColumnAction> Columns { get; }
    }
}
