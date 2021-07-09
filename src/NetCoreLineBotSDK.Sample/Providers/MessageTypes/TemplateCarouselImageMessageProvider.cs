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
    public class TemplateCarouselImageMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TemplateCarouselImageMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var columns = new List<ImageCarouselColumnAction>();

            columns.Add(new ImageCarouselColumnAction("https://via.placeholder.com/400x400/333.png/fff", new MessageAction("Image A")));
            columns.Add(new ImageCarouselColumnAction("https://via.placeholder.com/400x400/333.png/fff", new MessageAction("Image B")));

            var msg = new ImageCarouselTemplate(columns);

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
