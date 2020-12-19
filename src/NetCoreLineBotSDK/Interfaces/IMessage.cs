using System;
using System.Collections.Generic;
using System.Text;
using NetCoreLineBotSDK.Enums;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface IMessage : IRequestMessage
    {
        public LineMessageType Type { get; }
    }
}
