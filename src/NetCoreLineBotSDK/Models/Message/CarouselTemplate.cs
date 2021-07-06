using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Message
{
    public class CarouselTemplate : ITemplate
    {
        public CarouselTemplate(List<CarouselColumnMultipleAction> columns)
        {
            Columns = columns;
        }

        public string Type => "carousel";

        public List<CarouselColumnMultipleAction> Columns { get; set; }
    }
}
