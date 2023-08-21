using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parfume.Core.Entities;
using Parfume.Core.Entities.BaseEntities;

namespace Parfume.App.Context
{
    public class ParfumeDbContext: IdentityDbContext<AppUser>
    {
   
        public DbSet<FakeSlider> FakeSlides { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Parfum> Parfums { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<ParfumVolume> ParfumeVolumes { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<SettingContact> SettingContact { get; set; }
        public DbSet<SettingNavbar> SettingNavbar { get; set; }
        public DbSet<SettingAbout> SettingAbout { get; set; }
        public DbSet<SettingHomePage> SettingHomePage { get; set; }
        public DbSet<SettingFooter> SettingFooter { get; set; }
        public DbSet<SendMessage> Messages { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Functions> Functions { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<GiftBox> GiftBoxes { get; set; }
        public DbSet<Slider> Slides { get; set; }

        public ParfumeDbContext(DbContextOptions<ParfumeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
     
        }
    }
}
