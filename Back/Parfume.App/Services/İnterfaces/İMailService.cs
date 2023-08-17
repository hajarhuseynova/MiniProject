namespace Parfume.App.Services.İnterfaces
{
    public interface IMailService
    {
        public Task Send(string from, string to, string link, string subject);

    }
}
