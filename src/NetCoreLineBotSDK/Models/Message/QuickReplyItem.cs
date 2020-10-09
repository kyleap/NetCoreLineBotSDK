using NetCoreLineBotSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models.Message
{
    public class QuickReply
    {
        public List<QuickReplyItem> Items = new List<QuickReplyItem>();
    }

    public class QuickReplyItem
    {
        public string type => "action";
        public string imageUrl { get; set; }
        public IAction action { get; set; }
    }
}
