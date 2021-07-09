using NetCoreLineBotSDK.Enums;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Models.Message
{
    public class ImageMapMessage : BaseMessage, IMessage
    {
        /// <summary>
        /// Image Map Message
        /// </summary>
        /// <param name="imageUrl">Base URL of the image (Max character limit: 1000)</param>
        /// <param name="imageWidth">Width of base image in pixels. Set to 1040.</param>
        /// <param name="imageHeigth">Height of base image. Set to the height that corresponds to a width of 1040 pixels.</param>
        /// <param name="actions">Action when tapped</param>
        /// <param name="altText">Alternative text (Max character limit: 400)</param>
        /// <param name="video">videos</param>
        /// <param name="quickReply">Quick reply button objects. Max: 13 objects</param>
        public ImageMapMessage(string imageUrl, int imageWidth, int imageHeigth, List<IAction> actions, string altText = "image map", ImageMapVideo video = null)
        {
            BaseUrl = imageUrl;
            Actions = actions;
            AltText = altText;
            Video = video;
            BaseSize = new Basesize()
            {
                width = imageWidth,
                height = imageHeigth,
            };
        }
        public LineMessageType Type => LineMessageType.Imagemap;

        public string BaseUrl { get; }
        public string AltText { get; }
        public Basesize BaseSize { get; }
        public List<IAction> Actions { get; }
        public ImageMapVideo Video { get; }
    }

    public class Basesize
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ImageMapVideo
    {
        public string originalContentUrl { get; set; }
        public string previewImageUrl { get; set; }
        public ActionArea area { get; set; }
        public Externallink externalLink { get; set; }
    }

    public class Externallink
    {
        public string linkUri { get; set; }
        public string label { get; set; }
    }

}
