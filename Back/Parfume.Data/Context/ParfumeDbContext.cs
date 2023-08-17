﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parfume.Core.Entities;

namespace Parfume.App.Context
{
    public class ParfumeDbContext: IdentityDbContext<AppUser>
    {

        public DbSet<FakeSlider> FakeSlides { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }
        public ParfumeDbContext(DbContextOptions<ParfumeDbContext> options) : base(options)
        {

        }

    }
}
