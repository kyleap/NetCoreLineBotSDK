using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageAspectRatioType
    {
        /// <summary>
        /// 1.51:1
        /// </summary>
        rectangle,
        /// <summary>
        /// 1:1
        /// </summary>
        square
    }
}
