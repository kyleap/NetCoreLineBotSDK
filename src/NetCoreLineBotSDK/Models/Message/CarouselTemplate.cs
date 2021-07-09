using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;

namespace NetCoreLineBotSDK.Models.Message
{
    public class CarouselTemplate : BaseMessage, ITemplate
    {
        public CarouselTemplate(List<CarouselColumnMultipleAction> columns)
        {
            Columns = columns;
        }

        public string Type => "carousel";

        public List<CarouselColumnMultipleAction> Columns { get; }
    }
}
