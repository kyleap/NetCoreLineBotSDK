using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Models
{
    public class LineSetting
    {
        public string ChannelSecret { get; set; }
        public string ChannelAccessToken { get; set; }
        public string AccountLinkUrl { get; set; }
    }
}
