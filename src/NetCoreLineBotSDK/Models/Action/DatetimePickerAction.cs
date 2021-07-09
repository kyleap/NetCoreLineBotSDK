using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class DatetimePickerAction : IAction
    {
        public DatetimePickerAction(string label, string data, DatetimeActionModel mode)
        {
            Label = label;
            Data = data;
            Mode = mode;
        }

        public string Label { get; }
        public string Data { get; }
        public DatetimeActionModel Mode { get; }
        
        public string Initial { get; set; }
        
        public string Max { get; set; }
        
        public string Min { get; set; }
        public ActionType Type => ActionType.Datetimepicker;
        
        public ActionArea Area { get; set; }
    }
}