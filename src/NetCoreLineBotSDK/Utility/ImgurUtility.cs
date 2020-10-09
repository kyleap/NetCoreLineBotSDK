using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Microsoft.Extensions.Options;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models.LineObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Utility
{
    public class ImgurUtility : IImageUtility
    {
        private readonly ImgurSetting setting;
        public async Task<string> UploadImageAsync(Stream stream)
        {
            var apiClient = new ApiClient(setting.ClientId);
            var httpClient = new HttpClient();

            var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
            var imageUpload = await imageEndpoint.UploadImageAsync(stream);
            return imageUpload.Link;
        }
    }
}
