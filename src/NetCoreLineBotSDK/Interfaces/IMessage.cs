using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface IMessage
    {
        public LineMessageType Type { get; }
    }
}
