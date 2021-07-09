using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreLineBotSDK.Enums;

namespace NetCoreLineBotSDK.Sample.Providers.MessageTypes
{
    public class ActionProvider : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public ActionProvider(MessageRequestDTO request)
        {
            _request = request;
        }
        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var actions = new List<CarouselColumnMultipleAction>();

            // Postback action
            var postback = new List<IAction>()
            {
                new PostbackAction("Postback Action", "Postback Action Data")
            };
            actions.Add(new CarouselColumnMultipleAction("Postback", postback)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });

            // Message action
            var messageAction = new List<IAction>()
            {
                new MessageAction("Message Action")
            };
            actions.Add(new CarouselColumnMultipleAction("Message", messageAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });
            
            // Uri action
            var uriAction = new List<IAction>()
            {
                new UriAction("https://github.com/kyleap/NetCoreLineBotSDK", "URI Action")
            };
            actions.Add(new CarouselColumnMultipleAction("URI", uriAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });
            
            // Datetime picker action
            var dateTimeAction = new List<IAction>()
            {
                new DatetimePickerAction("Datetime Action", "datetime_postback", DatetimeActionModel.datetime)
            };
            actions.Add(new CarouselColumnMultipleAction("Datetime Action", dateTimeAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });

            // Camera action
            var cameraAction = new List<IAction>()
            {
                new CameraAction("Camera Action")
            };
            actions.Add(new CarouselColumnMultipleAction("Camera Action", cameraAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });
            
            // Camera action
            var cameraRollAction = new List<IAction>()
            {
                new CameraRollAction("Camera Action")
            };
            actions.Add(new CarouselColumnMultipleAction("Camera Roll Action", cameraRollAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });
            
            // Location action
            var locationAction = new List<IAction>()
            {
                new LocationAction("Location Action")
            };
            actions.Add(new CarouselColumnMultipleAction("Location Action", locationAction)
            {
                ThumbnailImageUrl = "https://via.placeholder.com/200x150/333.png/fff"
            });
            
            var msg = new CarouselTemplate(actions);

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
