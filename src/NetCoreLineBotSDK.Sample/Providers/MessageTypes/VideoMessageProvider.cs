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
    public class VideoMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public VideoMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }

        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new VideoMessage(
                originalContentUrl: "https://i.imgur.com/n8QsXTk.mp4",
                previewImageUrl: "https://i.imgur.com/oLvTjtu.png");

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
