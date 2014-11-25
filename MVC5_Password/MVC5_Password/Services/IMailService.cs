using System;
namespace MVC5_Password.Services
{
   public interface IMailService
    {
        bool SendMail(string from, string to, string subject, string body);
    }
}
