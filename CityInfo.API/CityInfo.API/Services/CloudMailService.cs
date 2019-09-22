using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@mycompany.com";
        private string _mailForm = "admin@mycompany.com";

        public void Send(string sub, string message)
        {
            Debug.WriteLine($"Mail from {_mailForm} to {_mailTo}, with CloudMailService.");
            Debug.WriteLine($"Subject: {sub}");
            Debug.WriteLine($"Message: {message}");

        }
    }
}
