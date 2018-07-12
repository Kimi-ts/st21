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

            builder.Entity<SaleTag>()
                    .HasKey(t => new { t.TagId, t.SaleId });

            builder.Entity<SaleTag>()
                    .HasOne(st => st.Sale)
                    .WithMany("SaleTags");

            builder.Entity<SaleTag>()
                    .HasOne(ts => ts.Tag)
                    .WithMany("SaleTags");
        }

        public DbSet<SiteConfig> SiteConfig { get; set; }
        public DbSet<SocialNetworkItem> SocialNetworkItems { get; set; }
        public DbSet<PageData> PageDataItems { get; set; }
        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SaleTag> SaleTag { get; set; }
    }
}
