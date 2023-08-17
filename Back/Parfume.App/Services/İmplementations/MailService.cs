using Parfume.App.Services.İnterfaces;
using System.Net;
using System.Net.Mail;

namespace Parfume.App.Services.İmplementations
{
    public class MailService : IMailService
    {
        public async Task Send(string from, string to, string link, string subject)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(from);
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = $"<a href='{link}'>Click me</a>";
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("hajarih@code.edu.az", "ixiyzvbqxblbdtka");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mm);
        }

    }
}
