using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Interfaces
{
    public interface IProviderFactory
    {
        Task<IReplyIntent> GetProvidersAsync(MessageRequestDTO request);
    }
}
