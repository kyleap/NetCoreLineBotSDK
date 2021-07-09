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
    public class ImageMapWithVideoMessageProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public ImageMapWithVideoMessageProvider(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var actions = new List<IAction>() {
                new UriAction("https://github.com/kyleap/NetCoreLineBotSDK","Github")
                {
                    area = new ActionArea()
                    {
                        x = 0,
                        y = 586,
                        width = 520,
                       height = 454
                    }
                },
                new MessageAction("Hello")
                {
                    area = new ActionArea()
                    {
                        x = 520,
                        y = 586,
                        width = 520,
                       height = 454
                    }
                }
            };

            var msg = new ImageMapMessage("https://via.placeholder.com/1040x1040/333.png/fff", 1040, 1040, actions, video: new ImageMapVideo()
            {
                originalContentUrl = "https://i.imgur.com/n8QsXTk.mp4",
                previewImageUrl = "https://i.imgur.com/oLvTjtu.png",
                area = new ActionArea()
                {
                    x = 0,
                    y = 0,
                    width = 1040,
                    height = 585
                },
                externalLink = new Externallink()
                {
                    linkUri = "https://github.com/kyleap/NetCoreLineBotSDK",
                    label = "See More"
                }
            });

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
