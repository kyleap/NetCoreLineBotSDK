using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineMessageType
    {
        text,
        sticker,
        image,
        video,
        audio,
        template,
        flex,
        location
    }
}
