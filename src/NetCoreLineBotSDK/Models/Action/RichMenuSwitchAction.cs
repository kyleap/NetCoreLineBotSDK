using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class RichMenuSwitchAction : IAction
    {
        public RichMenuSwitchAction(string richMenuAliasId, string data)
        {
            RichMenuAliasId = richMenuAliasId;
            Data = data;
            Label = "test";
        }

        public ActionType Type => ActionType.Richmenuswitch;

        public string Label { get; set; }

        public string RichMenuAliasId { get; set; }

        public string Data { get; set; }
    }
}