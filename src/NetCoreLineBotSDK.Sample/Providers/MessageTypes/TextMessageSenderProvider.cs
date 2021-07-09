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
    public class TextMessageSenderProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TextMessageSenderProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new TextMessage(@$"改變發送者跟大頭貼");
                
            msg.Sender = new MessageSender()
            {
                Name = "熊大",
                IconUrl =  "https://i.imgur.com/f3kvAba.png"
            };

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
