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
    public class TextMessageQuickReplyProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TextMessageQuickReplyProvider(MessageRequestDTO request)
        {
            _request = request;
        }
        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new TextMessage(@$"您可以在任何Message Types回傳Quick Reply");

            msg.QuickReply = new QuickReply()
            {
                Items = new List<QuickReplyItem>()
                {
                    new QuickReplyItem()
                    {
                        action = new MessageAction(@$"Hello, Quick Reply")
                    }
                }
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
