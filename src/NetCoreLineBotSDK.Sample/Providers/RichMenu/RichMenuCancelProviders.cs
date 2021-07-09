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
    public class RichMenuCancelProviders : IReplyIntent
    {
        private readonly MessageRequestDTO _request;
        private readonly ILineMessageUtility _lineMessageUtility;

        public RichMenuCancelProviders(ILineMessageUtility lineMessageUtility,MessageRequestDTO request)
        {
            _lineMessageUtility = lineMessageUtility;
            _request = request;
        }

        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            await _lineMessageUtility.UnLinkRichMenuToUser(_request.UserId);

            var msg = new TextMessage($"已取消顯示選單");

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
