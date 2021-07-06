using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class LocationAction : IAction
    {
        public LocationAction(string _label)
        {
            Label = _label;
        }
        public ActionType Type => ActionType.Location;
        public string Label { get; set; }

        public ActionArea area { get; set; }
    }

}
