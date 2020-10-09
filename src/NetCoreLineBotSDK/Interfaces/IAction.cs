using NetCoreLineBotSDK.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface IAction
    {
        public ActionType Type { get; }
        public string Label { get; set; }
    }
}
