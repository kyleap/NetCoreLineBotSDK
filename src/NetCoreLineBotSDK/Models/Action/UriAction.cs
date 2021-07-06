using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;

namespace NetCoreLineBotSDK.Models.Action
{
    public class UriAction : IAction, IRequestMessage
    {
        public UriAction(string uri, string label)
        {
            Uri = uri;
            LinkUri = uri;
            Label = label;
        }
        public string Uri { get; }

        /// <summary>
        /// Imagemap action objects 
        /// </summary>
        public string LinkUri { get; }
        public ActionType Type => ActionType.Uri;
        public string Label { get; }

        public ActionArea area { get; set; }
    }

}
