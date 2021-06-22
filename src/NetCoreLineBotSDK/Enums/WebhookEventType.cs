using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum WebhookEventType
    {
        Message,
        Follow,
        Unfollow,
        Postback,
        AccountLink,
        Beacon
    }
}
