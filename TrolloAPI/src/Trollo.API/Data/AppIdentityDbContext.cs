using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trollo.API.Data.Entities;
using Trollo.Identity.Identity;

namespace Trollo.API.Data
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, UserRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            AddAuditInfo();
            return base.SaveChangesAsync();
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x =>
                x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var now = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added) ((BaseEntity) entry.Entity).CreatedAt = now;
                ((BaseEntity) entry.Entity).ModifiedAt = now;
            }
        }
    }
}