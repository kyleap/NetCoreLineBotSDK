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
        public ActionType Type => ActionType.location;
        public string Label { get; set; }
    }

}
