using NetCoreLineBotSDK.Interfaces;
using NetCoreLineBotSDK.Models;
using NetCoreLineBotSDK.Models.Message;
using NetCoreLineBotSDK.Models.Message.RichMenu;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface ILineMessageUtility
    {
        Task<Richmenu> CreateRichMenuAsync(CreateRichmenu richmenu);
        Task DeleteRichMenu(string richMenuId);
        Task<Stream> GetContentBytesAsync(string messageId);
        Task<List<string>> GetRichMenuListAsync();
        Task<UserProfile> GetUserProfile(string userId);
        Task ReplyMessageAsync(string replyToken, IList<IMessage> messages);
        Task ReplyMessageAsync(string replyToken, IList<IRequestMessage> messages);
        Task ReplyMessageAsync(string replyToken, params string[] messages);
        Task ReplyMessageByJsonAsync(string replyToken, string jsonString);
        Task ReplyTemplateMessageAsync(string replyToken, ButtonTemplate template);
        Task ReplyTemplateMessageAsync(string replyToken, CarouselTemplate template);
        Task ReplyTemplateMessageAsync(string replyToken, ConfirmTemplate template);
        Task ReplyTemplateMessageAsync(string replyToken, IList<ITemplate> templates);
        Task ReplyTemplateMessageAsync(string replyToken, ImageCarouselTemplate template);
        Task SetDefaultRichMenuAsync(string richMenuId);
        Task UploadRichMenuImage(string imgUrl, string richMenuId);
    }
}