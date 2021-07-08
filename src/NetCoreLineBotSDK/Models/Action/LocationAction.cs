using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class LocationAction : IAction
    {
        public LocationAction(string label)
        {
            Label = label;
        }
        public ActionType Type => ActionType.Location;
        public string Label { get;}
        public ActionArea area { get; set; }
    }

}
