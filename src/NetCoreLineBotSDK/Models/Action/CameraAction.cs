using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class CameraAction : IAction
    {
        public ActionType Type => ActionType.camera;
        public string Label { get; set; }
    }

}
