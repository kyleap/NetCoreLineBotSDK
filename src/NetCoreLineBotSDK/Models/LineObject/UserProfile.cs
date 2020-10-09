using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models
{
    public class UserProfile
    {
        public string userId { get; set; }
        public string displayName { get; set; }
        public string pictureUrl { get; set; }
        public string statusMessage { get; set; }
    }

}
