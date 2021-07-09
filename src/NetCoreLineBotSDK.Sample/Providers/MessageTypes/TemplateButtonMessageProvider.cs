using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Providers.MessageTypes
{
    public class TemplateButtonMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TemplateButtonMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new ButtonTemplate("Buttons", new List<IAction>()
            {
                new MessageAction("Buttion1"),
                new MessageAction("Buttion2")
            }, thumbnailImageUrl: "https://via.placeholder.com/200x150/333.png/fff");


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
