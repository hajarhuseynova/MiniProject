using Microsoft.EntityFrameworkCore;
using Parfume.App.Context;
using Parfume.App.Services.İnterfaces;
using Parfume.Core.Entities;

namespace Parfume.App.Services.İmplementations
{
    public class SettingService : ISettingService
    {
        private readonly ParfumeDbContext _context;

        public SettingService(ParfumeDbContext context)
        {
            _context = context;
        }

        public async Task<SettingFooter?> Get()
        {
            SettingFooter? setting = await _context.SettingFooter.FirstOrDefaultAsync();
            return setting;
        }
        public async Task<SettingNavbar?> GetAll()
        {
            SettingNavbar? SettingNavbar = await _context.SettingNavbar.FirstOrDefaultAsync();
            return SettingNavbar;
        }
       

    }
}
