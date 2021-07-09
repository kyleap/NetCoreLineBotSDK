using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Providers.MessageTypes
{
    public class StickerMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public StickerMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            // Api reference: https://developers.line.biz/media/messaging-api/sticker_list.pdf
            var msg = new StickerMessage(446,1988);

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
