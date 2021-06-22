using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum ImageAspectRatioType
    {
        /// <summary>
        /// 1.51:1
        /// </summary>
        Rectangle,
        /// <summary>
        /// 1:1
        /// </summary>
        Square
    }
}
