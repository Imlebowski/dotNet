using System;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = Startup.Configuration["Mail:To"];
        private string _mailFrom = Startup.Configuration["Mail:From"];
        public void Send(string sub, string msg)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with Local");
            Console.WriteLine($"Subject: {sub}");
            Console.WriteLine($"Message: {msg}");
        }
    }
}