using NetCoreLineBotSDK.Sample.Interfaces;
using NetCoreLineBotSDK.Sample.Models;
using NetCoreLineBotSDK.Sample.Providers.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Sample.Providers
{
    public class ProviderFactory : IProviderFactory
    {
        public async Task<IReplyIntent> GetProvidersAsync(MessageRequestDTO request)
        {
            // Rule Base Intents
            var providers = new Dictionary<string, IReplyIntent>();

            providers.Add("default", new EchoProvider(request));

            // Message Types
            providers.Add("/text", new TextMessageProviders(request));
            providers.Add("/sticker", new StickerMessageProviders(request));
            providers.Add("/image", new ImageMessageProviders(request));
            providers.Add("/video", new VideoMessageProviders(request));
            providers.Add("/audio", new AudioMessageProviders(request));
            providers.Add("/location", new LocationMessageProviders(request));


            await Task.CompletedTask;

            return providers.ContainsKey(request.Intent.ToLower()) ? providers[request.Intent.ToLower()] : providers["default"];
        }
    }
}
