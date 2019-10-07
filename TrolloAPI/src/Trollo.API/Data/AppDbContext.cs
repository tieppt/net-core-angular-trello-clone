using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trollo.API.Data.Entities;

namespace Trollo.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<ListCard> ListCards { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        /// <summary>
        ///     Override default behavior when create or update data
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        /// <summary>
        ///     Override default behavior when create or update data async
        /// </summary>
        /// <returns></returns>
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