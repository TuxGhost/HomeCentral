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
        if (_smtpClient == null)
        {
            int port = int.Parse(_config.GetValue<string>("smtp:port"));
            string host = _config.GetValue<string>("smtp:host");
            string user = _config.GetValue<string>("smtp:user");
            string password = _config.GetValue<string>("smtp:Password");
            _smtpClient = new SmtpClient
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,                
                EnableSsl = true,
                Host = host,
                Port = port,                
                Credentials = new NetworkCredential(user, password)
            };
            MailMessage mailMessage = new MailMessage("noreply@peterkuda.be", email)
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
