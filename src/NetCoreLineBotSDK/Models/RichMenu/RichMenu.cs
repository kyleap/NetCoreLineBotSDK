using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models.Message.RichMenu
{
    public class Richmenu
    {
        public string richMenuId { get; set; }
        public string name { get; set; }
        public RichMenuSize size { get; set; }
        public string chatBarText { get; set; }
        public bool selected { get; set; }
        public RichMenuArea[] areas { get; set; }
    }
}
