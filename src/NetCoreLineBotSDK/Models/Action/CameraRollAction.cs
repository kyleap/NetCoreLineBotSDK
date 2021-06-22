using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class CameraRollAction : IAction
    {
        public ActionType Type => ActionType.CameraRoll;
        public string Label { get; set; }
    }

}
