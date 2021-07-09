using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreLineBotSDK.Models.Action;

namespace NetCoreLineBotSDK.Sample.Providers.MessageTypes
{
    public class TextMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TextMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }
        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new TextMessage(@$"Hello, world");

            await Task.CompletedTask;

            return new List<IRequestMessage>
            {
                msg
            };
        }

        public IList<IRequestMessage> GetReplyMessagesByPostbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
