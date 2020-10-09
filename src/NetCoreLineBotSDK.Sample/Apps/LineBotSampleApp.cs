using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.LineObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Apps
{
    public class LineBotSampleApp : LineBotApp
    {
        private readonly ILineMessageUtility lineMessageUtility;
        public LineBotSampleApp(ILineMessageUtility _lineMessageUtility) : base(_lineMessageUtility)
        {
            lineMessageUtility = _lineMessageUtility;
        }

        protected override async Task OnMessageAsync(LineEvent ev)
        {
            await lineMessageUtility.ReplyMessageAsync(ev.replyToken, $"You Said:{ev.message.Text}");
        }
    }
}
