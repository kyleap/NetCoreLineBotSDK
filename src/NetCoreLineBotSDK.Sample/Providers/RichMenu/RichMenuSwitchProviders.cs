using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Providers.RichMenu
{
    public class RichMenuSwitchProviders : IReplyIntent
    {
        private readonly MessageRequestDTO _request;

        public RichMenuSwitchProviders(MessageRequestDTO request)
        {
            _request = request;
        }


        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            var msg = new ButtonTemplate("Rich Menus", new List<IAction>()
            {
                new RichMenuSwitchAction("richmenu-a", "richmenu-a-postback"),
                new RichMenuSwitchAction("richmenu-b", "richmenu-b-postback"),
                new RichMenuSwitchAction("richmenu-c", "richmenu-c-postback")
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
