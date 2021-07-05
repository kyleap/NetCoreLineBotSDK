using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Models
{
    public class MessageRequestDTO
    {
        public string Intent { get; set; }
        public dynamic PostbackParams { get; set; }
        public bool IsFromGroup { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
    }
}
