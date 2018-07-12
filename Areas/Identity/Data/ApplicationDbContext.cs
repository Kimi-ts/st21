using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StCore21.Models;

namespace StStore21.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<SiteConfig> SiteConfig { get; set; }
        public DbSet<SocialNetworkItem> SocialNetworkItems { get; set; }
        public DbSet<PageData> PageDataItems { get; set; }
        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}
