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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Utility
{
    public class LineMessageUtility : ILineMessageUtility
    {
        private readonly string accessToken;
        private static string lineMessageReplyApiBaseUrl = "https://api.line.me/v2/bot/message/reply";
        private static string lineMessageProfileApiBaseUrl = "https://api.line.me/v2/bot/profile";
        private static string lineMessageRichMenuApiBaseUrl = "https://api.line.me/v2/bot/richmenu";
        private static string lineMessageRichMenuAllUserApiBaseUrl = "https://api.line.me/v2/bot/user/all/richmenu";

        public LineMessageUtility(IOptions<LineSetting> lineSetting)
        {
            accessToken = lineSetting.Value.ChannelAccessToken;
        }

        public async Task<UserProfile> GetUserProfile(string userId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{lineMessageProfileApiBaseUrl}/{userId}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                    var response = await httpClient.SendAsync(request);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // 這邊未來應該要 log 起來
                        throw new Exception("get_profile_error");
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserProfile>(result);
                }
            }
        }

        public async Task ReplyMessageAsync(string replyToken, params string[] messages)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

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
                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        public async Task ReplyMessageAsync(string replyToken, IList<IMessage> messages)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    foreach (var message in messages)
                    {
                        req.Messages.Add(message);
                    }

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        }
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        public async Task ReplyTemplateMessageAsync(string replyToken, IList<ITemplate> templates)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    foreach (var template in templates)
                    {
                        req.Messages.Add(new TemplateMessageBase()
                        {
                            Template = template
                        });
                    }

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ReplyTemplateMessageAsync(string replyToken, ButtonTemplate template)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    req.Messages.Add(new TemplateMessageBase()
                    {
                        Template = template
                    });

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ReplyTemplateMessageAsync(string replyToken, ConfirmTemplate template)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    req.Messages.Add(new TemplateMessageBase()
                    {
                        Template = template
                    });

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ReplyTemplateMessageAsync(string replyToken, CarouselTemplate template)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    req.Messages.Add(new TemplateMessageBase()
                    {
                        Template = template
                    });

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ReplyTemplateMessageAsync(string replyToken, ImageCarouselTemplate template)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    req.Messages.Add(new TemplateMessageBase()
                    {
                        Template = template
                    });

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task ReplyMessageByJsonAsync(string replyToken, string jsonString)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageReplyApiBaseUrl}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    LineMessageReq req = new LineMessageReq();
                    req.ReplyToken = replyToken;

                    req.Messages.Add(new FlexMessage()
                    {
                        Contents = JsonConvert.DeserializeObject(jsonString)
                    });

                    var postJson = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        },
                        Formatting = Formatting.Indented
                    }).Replace("\"", @"""");

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<Stream> GetContentBytesAsync(string messageId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api-data.line.me/v2/bot/message/{messageId}/content"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                    var response = await httpClient.SendAsync(request);
                    var results = await response.Content.ReadAsStreamAsync();
                    return results;
                }
            }
        }

        public async Task<List<string>> GetRichMenuListAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{lineMessageRichMenuApiBaseUrl}/list"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                    var richMenuRes = JsonConvert.DeserializeObject<RichMenuResponse>(result);
                    if (richMenuRes.richmenus.Count == 0) return new List<string>();
                    return richMenuRes.richmenus.Select(c => c.richMenuId).ToList();
                }
            }
        }
        public async Task<Richmenu> CreateRichMenuAsync(CreateRichmenu richmenu)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), lineMessageRichMenuApiBaseUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    var postJson = JsonConvert.SerializeObject(richmenu, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy()
                        }
                    });

                    request.Content = new StringContent(postJson);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await httpClient.SendAsync(request);
                    var results = await response.Content.ReadAsStringAsync();
                    var richmenu_res = JsonConvert.DeserializeObject<Richmenu>(results);
                    return richmenu_res;
                };
            }
        }

        public async Task SetDefaultRichMenuAsync(string richMenuId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageRichMenuAllUserApiBaseUrl}/{richMenuId}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                    var response = await httpClient.SendAsync(request);
                    var results = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        await DeleteRichMenu(richMenuId);
                    }
                }
            }
        }

        public async Task UploadRichMenuImage(string imgUrl, string richMenuId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{lineMessageRichMenuApiBaseUrl}/{richMenuId}/content"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                    var imgBytes = GetImage(imgUrl);
                    request.Content = new ByteArrayContent(imgBytes);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    var response = await httpClient.SendAsync(request);
                    var results = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        await DeleteRichMenu(richMenuId);
                    }
                };
            }
        }

        public async Task DeleteRichMenu(string richMenuId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{lineMessageRichMenuApiBaseUrl}/{richMenuId}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }

        private byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }
        }
    }
}
