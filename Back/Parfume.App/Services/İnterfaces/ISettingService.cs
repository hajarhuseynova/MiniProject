using Parfume.Core.Entities;

namespace Parfume.App.Services.İnterfaces
{
    public interface ISettingService
    {
        public Task<SettingFooter?> Get();
        public Task<SettingNavbar?> GetAll();
    


    }
}
