using Foos.Api.Database.Context.Configurations;
using Foos.Api.Database.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foos.Api.Database.Context
{
    public class FoosDbContext : DbContext
    {
        public FoosDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FooCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RecommendedAmountPerDayEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FooEntityConfiguration());
        }

        public DbSet<MeasurementEntity> Measurements { get; set; }
        public DbSet<FooCategoryEntity> FooCategories { get; set; }
        public DbSet<RecommendedAmountPerDayEntity> RecommendedAmountPerDayEntries { get; set; }
        public DbSet<FooEntity> Foos { get; set; }
    }
}
