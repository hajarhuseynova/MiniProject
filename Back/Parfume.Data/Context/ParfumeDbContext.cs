using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parfume.Core.Entities;

namespace Parfume.App.Context
{
    public class ParfumeDbContext: IdentityDbContext<AppUser>
    {

        public DbSet<FakeSlider> FakeSlides { get; set; }
        public DbSet<SettingContact> SettingContact { get; set; }
        public DbSet<SettingNavbar> SettingNavbar { get; set; }
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
            modelBuilder.Entity<Parfum>()
                .HasOne(e => e.Rating)
                .WithOne(e => e.Parfum)
                .HasForeignKey<Rating>(e => e.ParfumId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
