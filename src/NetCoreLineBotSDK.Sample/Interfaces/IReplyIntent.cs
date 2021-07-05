using NetCoreLineBotSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Interfaces
{
    public interface IReplyIntent
    {
        Task<IList<IRequestMessage>> GetReplyMessagesAsync();
        IList<IRequestMessage> GetReplyMessagesByPostbackAsync();
    }
}
