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
    public class TemplateCarouselMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public TemplateCarouselMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var columns = new List<CarouselColumnMultipleAction>();

            // column A
            var columna_actions = new List<IAction>()
            {
                new MessageAction("button A")
            };
            columns.Add(new CarouselColumnMultipleAction("column A", columna_actions)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });

            // column B
            var columnb_actions = new List<IAction>()
            {
                new MessageAction("button B")
            };
            columns.Add(new CarouselColumnMultipleAction("column B", columnb_actions)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });

            var msg = new CarouselTemplate(columns);

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
