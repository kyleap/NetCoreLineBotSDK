using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Providers
{
    public class EchoProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public EchoProvider(MessageRequestDTO request)
        {
            _request = request;
        }

        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var text = new TextMessage()
            {
                Text = @$"You Said: {_request.Message}"
            };

            await Task.CompletedTask;

            return new List<IRequestMessage>
            {
                text
            };
        }

        public IList<IRequestMessage> GetReplyMessagesByPostbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
