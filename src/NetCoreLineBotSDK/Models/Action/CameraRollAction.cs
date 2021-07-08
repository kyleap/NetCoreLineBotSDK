using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class CameraRollAction : IAction
    {
        public CameraRollAction(string label)
        {
            Label = label;
        }
        public ActionType Type => ActionType.CameraRoll;
        public string Label { get; set; }
        public ActionArea area { get; set; }
    }

}
