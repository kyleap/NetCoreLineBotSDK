using System.Collections.Generic;

namespace NetCoreLineBotSDK.Models.Message.RichMenu
{
    public class RichMenuAliasResponse
    {
        public List<RichMenuAlias> aliases { get; set; }
    }
    public class RichMenuAlias
    {
        public string richMenuAliasId { get; set; }
        public string richMenuId { get; set; }
    }
}