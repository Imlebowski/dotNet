namespace CityInfo.API.Services
{
    public interface IMailService
    {
        void Send(string sub, string msg);
    }
}