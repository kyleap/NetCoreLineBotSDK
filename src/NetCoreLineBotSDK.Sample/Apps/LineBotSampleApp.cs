using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.LineObject;
using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetCoreLineBotSDK.Sample.Apps
{
    public class LineBotSampleApp : LineBotApp
    {
        private readonly ILineMessageUtility _lineMessageUtility;

        public IProviderFactory _factory { get; }

        public LineBotSampleApp(ILineMessageUtility lineMessageUtility, IProviderFactory factory) : base(lineMessageUtility)
        {
            _lineMessageUtility = lineMessageUtility;
            _factory = factory;
        }

        protected override Task OnFollowAsync(LineEvent ev)
        {
            return base.OnFollowAsync(ev);
        }

        protected override async Task OnMessageAsync(LineEvent ev)
        {
            // Get Line User Profile
            var lineUser = await _lineMessageUtility.GetUserProfile(ev.source.userId);

            var request = new MessageRequestDTO()
            {
                Intent = ev.message.Text,
                Message = ev.message.Text,
                UserId = ev.source.userId,
                DisplayName = lineUser.displayName,
                IsFromGroup = ev.source.type == "group",
                PostbackParams = ev.postback?.@params
            };

            if (ev.message.Type == NetCoreLineBotSDK.Enums.LineMessageType.Text)
            {
                var providers = await _factory.GetProvidersAsync(request);
                var replyMessages = await providers.GetReplyMessagesAsync();
                await _lineMessageUtility.ReplyMessageAsync(ev.replyToken, replyMessages);
            }
        }

        protected override async Task OnPostbackAsync(LineEvent ev)
        {
            var postback = JsonConvert.SerializeObject(ev);
            await _lineMessageUtility.ReplyMessageAsync(ev.replyToken, postback);
        }
    }
}
