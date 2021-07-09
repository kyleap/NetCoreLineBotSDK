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
        Task<UserProfile> GetUserProfile(string userId);
        Task<Stream> GetContentBytesAsync(string messageId);
        Task PushMessageAsync(string userId, params string[] messages);
        Task PushMessageAsync(string userId, IList<IRequestMessage> messages);
        Task PushMessageByJsonAsync(string userId, string jsonString);
        Task ReplyMessageAsync(string replyToken, IList<IRequestMessage> messages);
        Task ReplyMessageAsync(string replyToken, params string[] messages);
        Task ReplyMessageByJsonAsync(string replyToken, string jsonString);
        Task<Richmenu> GetRichMenuAsync(string richMenuId);
        Task<List<Richmenu>> GetRichMenuListAsync();
        Task<Richmenu> CreateRichMenuWithImageAsync(RichmenuDetail richmenuDetail, string imgUrl, string alias = "");
        Task SetDefaultRichMenuAsync(string richMenuId);
        Task LinkRichMenuToUser(string userId, string richMenuId);
        Task DeleteRichMenu(string richMenuId);
        Task<List<RichMenuAlias>> GetRichMenuAliasAsync();
        Task CreateRichMenuAliasAsync(string richMenuId, string aliasName);
        Task DeleteRichMenAliasAsync(string aliasName);
        Task UpdateRichMenAliasAsync(string richMenuId, string aliasName);
        Task<Richmenu> CreateRichMenuByJsonWithImageAsync(string json, string imgUrl, string alias = "");
        Task UnLinkRichMenuToUser(string userId);
    }
}