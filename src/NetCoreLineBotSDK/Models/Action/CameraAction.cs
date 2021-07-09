using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class CameraAction : IAction
    {
        public CameraAction(string label)
        {
            Label = label;
        }
        public ActionType Type => ActionType.Camera;
        public string Label { get;}
        
        public ActionArea Area { get; set; }
    }

}
