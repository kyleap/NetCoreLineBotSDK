namespace NetCoreLineBotSDK.Models.LineObject
{
    public class PostBackParams
    {
        /// <summary>
        /// Date selected by user. Only included in the date mode. Format: full-date
        /// </summary>
        public string date { get; }

        /// <summary>
        /// Time selected by the user. Only included in the time mode. Format: time-hour ":" time-minute
        /// </summary>
        public string time { get; }

        /// <summary>
        /// Date and time selected by the user. Only included in the datetime mode. Format: full-date "T" time-hour ":" time-minute
        /// </summary>
        public string dateTime { get; }
    }

}
