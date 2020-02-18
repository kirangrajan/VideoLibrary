using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

using IMD.VideoLibrary.UI.Models;

namespace IMD.VideoLibrary.UI
{
    public class EmailService 
    {
        public Task SendAsync()
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService
    {
        public Task SendAsync()
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager 
    {
        public ApplicationUserManager()
        {
        }

        public static ApplicationUserManager Create() 
        {
            var manager = new ApplicationUserManager();
            // Configure validation logic for usernames
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager 
    {
        public ApplicationSignInManager()
        {
        }

      
        public static ApplicationSignInManager Create()
        {
            return new ApplicationSignInManager();
        }
    }
}
