using System.IO;
using System.Threading.Tasks;

namespace NetCoreLineBotSDK.Interfaces
{
    public interface IImageUtility
    {
        Task<string> UploadImageAsync(Stream stream);
    }
}