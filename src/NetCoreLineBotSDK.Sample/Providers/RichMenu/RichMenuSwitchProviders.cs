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
        private readonly string _defaultRichMenuId;
        private readonly ILineMessageUtility _lineMessageUtility;

        public RichMenuSwitchProviders(ILineMessageUtility lineMessageUtility,MessageRequestDTO request, string defaultRichMenuId)
        {
            _lineMessageUtility = lineMessageUtility;
            _request = request;
            _defaultRichMenuId = defaultRichMenuId;
        }

        public async Task<IList<IRequestMessage>> GetReplyMessagesAsync()
        {
            // 需先建立RichMenu資訊後設定預設顯示的ID於appsettings.json
            var richMenu = await _lineMessageUtility.GetRichMenuAsync(_defaultRichMenuId);
            
            await _lineMessageUtility.LinkRichMenuToUser(_request.UserId, _defaultRichMenuId);

            var msg = new TextMessage($"切換選單至: {richMenu.name}，您可點擊三個區塊切換選單");

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
