using Microsoft.Extensions.Options;
using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Models.Message.RichMenu;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace NetCoreLineBotSDK.Utility
{
    public class LineMessageUtility : ILineMessageUtility
    {
        private readonly string _accessToken;
        private readonly string _accountLinkUrl;
        private readonly HttpClient _httpClient;
        private const string LineMessageUserBaseUrl = "https://api.line.me/v2/bot/user/";
        private const string LineMessageReplyApiBaseUrl = "https://api.line.me/v2/bot/message/reply";
        private const string LineMessageProfileApiBaseUrl = "https://api.line.me/v2/bot/profile";
        private const string LineMessageRichMenuApiBaseUrl = "https://api.line.me/v2/bot/richmenu";
        private const string LineMessageRichMenuAllUserApiBaseUrl = "https://api.line.me/v2/bot/user/all/richmenu";
        private const string LineMessageRichMenuAttachApiBaseUrl = "https://api-data.line.me/v2/bot/richmenu";
        private const string LineMessageLinkTokenUrl = "https://api.line.me/v2/bot/user/{userId}/linkToken";

        public LineMessageUtility(IOptions<LineSetting> lineSetting, HttpClient httpClient)
        {
            _accessToken = lineSetting.Value.ChannelAccessToken;
            _accountLinkUrl = lineSetting.Value.AccountLinkUrl;
            _httpClient = httpClient;
        }

        public async Task<UserProfile> GetUserProfile(string userId)
        {
            using var request =
                new HttpRequestMessage(new HttpMethod("GET"), $"{LineMessageProfileApiBaseUrl}/{userId}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                // 這邊未來應該要 log 起來
                throw new Exception("get_profile_error");
            }

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserProfile>(result);
        }

        public async Task ReplyMessageAsync(string replyToken, params string[] messages)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{LineMessageReplyApiBaseUrl}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");

            var req = new LineMessageReq {ReplyToken = replyToken};

            foreach (var message in messages)
            {
                req.Messages.Add(new TextMessage()
                {
                    Text = message
                });
            }

            var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });

            request.Content = new StringContent(postJson);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await _httpClient.SendAsync(request);
        }

        public async Task ReplyMessageAsync(string replyToken, IList<IRequestMessage> messages)
        {
            var req = new LineMessageReq {ReplyToken = replyToken};

            foreach (var message in messages)
            {
                switch (message)
                {
                    case IMessage:
                        req.Messages.Add(message);
                        break;
                    case ITemplate template:
                        req.Messages.Add(new TemplateMessageBase()
                        {
                            Template = template
                        });
                        break;
                    case IFlex template:
                        req.Messages.Add(template);
                        break;
                }
            }
            await MakePostRequestToLineApi(req);
        }

        public async Task ReplyMessageByJsonAsync(string replyToken, string jsonString)
        {
            var req = new LineMessageReq { ReplyToken = replyToken };
            req.Messages.Add(new FlexMessage(JsonConvert.DeserializeObject(jsonString)));
            await MakePostRequestToLineApi(req);
        }

        public async Task<Stream> GetContentBytesAsync(string messageId)
        {
            using var request = new HttpRequestMessage(new HttpMethod("GET"),
                $"https://api-data.line.me/v2/bot/message/{messageId}/content");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var response = await _httpClient.SendAsync(request);
            var results = await response.Content.ReadAsStreamAsync();
            return results;
        }

        public async Task<List<Richmenu>> GetRichMenuListAsync()
        {
            using var request =
                new HttpRequestMessage(new HttpMethod("GET"), $"{LineMessageRichMenuApiBaseUrl}/list");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var richMenuRes = JsonConvert.DeserializeObject<RichMenuResponse>(result);
            if (richMenuRes == null) return new List<Richmenu>();
            if (richMenuRes.richmenus.Count == 0) return new List<Richmenu>();
            return richMenuRes.richmenus;
        }

        public async Task<Richmenu> CreateRichMenuAsync(RichmenuDetail richmenuDetail)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"), LineMessageRichMenuApiBaseUrl);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");

            var postJson = JsonConvert.SerializeObject(richmenuDetail, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            request.Content = new StringContent(postJson);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await _httpClient.SendAsync(request);
            var results = await response.Content.ReadAsStringAsync();
            var richmenuRes = JsonConvert.DeserializeObject<Richmenu>(results);
            return richmenuRes;
        }

        public async Task SetDefaultRichMenuAsync(string richMenuId)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"),
                $"{LineMessageRichMenuAllUserApiBaseUrl}/{richMenuId}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var response = await _httpClient.SendAsync(request);
            var results = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                await DeleteRichMenu(richMenuId);
            }
        }

        public async Task UploadRichMenuImage(string imgUrl, string richMenuId)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"),
                $"{LineMessageRichMenuAttachApiBaseUrl}/{richMenuId}/content");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var imgBytes = GetImage(imgUrl);
            request.Content = new ByteArrayContent(imgBytes);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            var response = await _httpClient.SendAsync(request);
            var results = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                await DeleteRichMenu(richMenuId);
            }
        }

        public async Task DeleteRichMenu(string richMenuId)
        {
            using var request = new HttpRequestMessage(new HttpMethod("DELETE"),
                $"{LineMessageRichMenuApiBaseUrl}/{richMenuId}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var response = await _httpClient.SendAsync(request);
        }

        private byte[] GetImage(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            var response = (HttpWebResponse) request.GetResponse();

            using var dataStream = response.GetResponseStream();
            using var sr = new BinaryReader(dataStream);
            var bytes = sr.ReadBytes(100000000);

            return bytes;
        }

        public async Task LinkRichMenuToUser(string userId, string richMenuId)
        {
            using var request = new HttpRequestMessage(new HttpMethod("POST"),
                $"{LineMessageUserBaseUrl}/{userId}/richmenu/{richMenuId}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            var response = await _httpClient.SendAsync(request);
            var results = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                await DeleteRichMenu(richMenuId);
                throw new Exception("upload rich menu image failed");
            }
        }
        public string GetAccountLinkUrl()
        {
            return  $"{_accountLinkUrl}";
        }

        private async Task MakePostRequestToLineApi(LineMessageReq req)
        {
            var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented,
                Converters = { new StringEnumConverter(typeof(SnakeCaseNamingStrategy)) }
            }).Replace("\"", @"""");


            using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{LineMessageReplyApiBaseUrl}");
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_accessToken}");
            request.Content = new StringContent(postJson);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK) return;
            throw new Exception(content);
        }
    }
}