namespace NetCoreLineBotSDK.Interfaces
{
    public interface IFlex : IRequestMessage
    {
        public dynamic Contents { get; set; }
    }
}