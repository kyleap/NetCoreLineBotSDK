using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using NetCoreLineBotSDK.Sample.Providers.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Sample.Providers.RichMenu;

namespace NetCoreLineBotSDK.Sample.Providers
{
    public class ProviderFactory : IProviderFactory
    {
        private readonly IOptions<LineSetting> _setting;
        private readonly ILineMessageUtility _lineMessageUtility;

        public ProviderFactory(ILineMessageUtility lineMessageUtility, IOptions<LineSetting> setting)
        {
            _setting = setting;
            _lineMessageUtility = lineMessageUtility;
        }
        public async Task<IReplyIntent> GetProvidersAsync(MessageRequestDTO request)
        {
            // Rule Base Intents
            var providers = new Dictionary<string, IReplyIntent>();

            providers.Add("default", new EchoProvider(request));

            // Message Types
            providers.Add("/text", new TextMessageProvider(request));
            providers.Add("/sticker", new StickerMessageProvider(request));
            providers.Add("/image", new ImageMessageProvider(request));
            providers.Add("/video", new VideoMessageProvider(request));
            providers.Add("/audio", new AudioMessageProviders(request));
            providers.Add("/location", new LocationMessageProvider(request));
            providers.Add("/image-map", new ImageMapMessageProvider(request));
            providers.Add("/image-map-with-video", new ImageMapWithVideoMessageProvider(request));
            providers.Add("/template-buttons", new TemplateButtonMessageProvider(request));
            providers.Add("/template-confirm", new TemplateConfirmMessageProvider(request));
            providers.Add("/template-carousel", new TemplateCarouselMessageProvider(request));
            providers.Add("/template-carousel-images", new TemplateCarouselImageMessageProvider(request));
            
            // 你可以在任何Message Types 回傳 Quick Reply
            providers.Add("/quick-reply", new TextMessageQuickReplyProvider(request));
            
            // 改變發送者顯示名稱與大頭貼
            providers.Add("/sender", new TextMessageSenderProvider(request));
            
            // Flex Message
            providers.Add("/flex", new FlexMessageProvider(request));
            
            // Actions
            providers.Add("/action", new ActionProvider(request));
            
            // Rich Menu
            providers.Add("/richmenu", new RichMenuSwitchProviders(_lineMessageUtility, request, _setting.Value.DefaultRichMenuId));
            providers.Add("/richmenu-cancel", new RichMenuCancelProviders(_lineMessageUtility, request));

            await Task.CompletedTask;

            return providers.ContainsKey(request.Intent.ToLower()) ? providers[request.Intent.ToLower()] : providers["default"];
        }
    }
}
