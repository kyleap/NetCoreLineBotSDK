using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace NetCoreLineBotSDK.Enums
{
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum BeaconType
    {
        Enter,
        Banner,
        Stay
    }

}
