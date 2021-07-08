using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum ActionType
    {
        Postback,
        Message,
        Uri,
        Datetimepicker,
        Camera,
        CameraRoll,
        Location,
        Richmenuswitch
    }
}
