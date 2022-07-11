using Microsoft.EntityFrameworkCore;
using TransportScales.Data.Entities;
using TransportScales.Data.Extensions;

namespace TransportScales.Data
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Transport>();
            builder.Entity<Journal>();
            builder.Entity<TransportQuantity>();
        }


        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            this.OnBeforeSaving();
            return base.SaveChangesAsync(ct);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
