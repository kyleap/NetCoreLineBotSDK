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
        Task<Richmenu> CreateRichMenuAsync(RichmenuDetail richmenuDetail);
        Task DeleteRichMenu(string richMenuId);
        Task<Stream> GetContentBytesAsync(string messageId);
        Task<List<Richmenu>> GetRichMenuListAsync();
        Task<UserProfile> GetUserProfile(string userId);
        string GetAccountLinkUrl();
        Task ReplyMessageAsync(string replyToken, IList<IRequestMessage> messages);
        Task ReplyMessageAsync(string replyToken, params string[] messages);
        Task ReplyMessageByJsonAsync(string replyToken, string jsonString);
        Task SetDefaultRichMenuAsync(string richMenuId);
        Task UploadRichMenuImage(string imgUrl, string richMenuId);
        Task LinkRichMenuToUser(string userId, string richMenuId);
    }
}