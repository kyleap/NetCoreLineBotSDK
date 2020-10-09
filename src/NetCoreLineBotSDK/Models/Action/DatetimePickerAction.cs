using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class DatetimePickerAction : IAction
    {
        public string data { get; set; }
        public string mode { get; set; }
        public string initial { get; set; }
        public string max { get; set; }
        public string min { get; set; }
        public ActionType Type => ActionType.datetimepicker;
        public string Label { get; set; }
    }

}
