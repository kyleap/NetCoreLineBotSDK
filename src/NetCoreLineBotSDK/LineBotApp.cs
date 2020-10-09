using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.LineObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK
{
    public abstract class LineBotApp
    {
        private readonly ILineMessageUtility lineMessageUtility;
        public LineBotApp(ILineMessageUtility _lineMessageUtility)
        {
            lineMessageUtility = _lineMessageUtility;
        }
        public async Task RunAsync(IEnumerable<LineEvent> events)
        {
            foreach (var e in events)
            {
                switch (e.type)
                {
                    case Enums.WebhookEventType.Message:
                        await OnMessageAsync(e);
                        break;
                    case Enums.WebhookEventType.Follow:
                        await OnFollowAsync(e);
                        break;
                    case Enums.WebhookEventType.Unfollow:
                        await OnUnfollowAsync(e);
                        break;
                    case Enums.WebhookEventType.Postback:
                        await OnUnPostbackAsync(e);
                        break;
                    case Enums.WebhookEventType.Beacon:
                        await OnBeaconAsync(e);
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual Task OnMessageAsync(LineEvent ev) => Task.CompletedTask;
        protected virtual Task OnFollowAsync(LineEvent ev) => Task.CompletedTask;
        protected virtual Task OnUnfollowAsync(LineEvent ev) => Task.CompletedTask;
        protected virtual Task OnUnPostbackAsync(LineEvent ev) => Task.CompletedTask;
        protected virtual Task OnBeaconAsync(LineEvent ev) => Task.CompletedTask;
    }
}
