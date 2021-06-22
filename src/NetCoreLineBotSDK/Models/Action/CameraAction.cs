using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class CameraAction : IAction
    {
        public ActionType Type => ActionType.Camera;
        public string Label { get; set; }
    }

}
