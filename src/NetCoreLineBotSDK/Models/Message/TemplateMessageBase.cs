using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;

namespace NetCoreLineBotSDK.Models.Message
{
    public class TemplateMessageBase : IMessage
    {
        public LineMessageType Type => LineMessageType.Template;
        public string AltText => "此訊息不支援桌面版的Line";
        public ITemplate Template { get; set; }
    }
}
