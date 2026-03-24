using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace Home_Central.Services;

public class SmtpService : IEmailSender
{
    private readonly IConfiguration _config;    
    private SmtpClient _smtpClient = null!;
    
    public SmtpService(IConfiguration config) 
    { 
        _config = config;
    }
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {        
        if(_config == null)
        {
            return Task.FromException(new Exception("No configuration available"));
        }
        string noreply = _config.GetValue<string>("smtp:noreply") ?? "noreply@localhost";
        if (_smtpClient == null)
        {
            int port = int.Parse(_config.GetValue<string>("smtp:port"));
            string host = _config.GetValue<string>("smtp:host");
            string user = _config.GetValue<string>("smtp:user");
            string password = _config.GetValue<string>("smtp:Password");
            
            bool ssl = _config.GetValue<bool>("smtp:ssl", true);
            if (user != null) {
                _smtpClient = new SmtpClient
                {
                    UseDefaultCredentials = ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Host = host,
                    Port = port,
                    Credentials = new NetworkCredential(user, password)
                };
            } else
            {
                _smtpClient = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = false,
                    Host = host,
                    Port = port,
                    //Credentials = new NetworkCredential(user, password)

                };
            }
        }
        if( _smtpClient == null) { 
            MailMessage mailMessage = new MailMessage(noreply, email)
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            _smtpClient.Send(mailMessage);                        
        }
        return Task.CompletedTask;        
    }
}
