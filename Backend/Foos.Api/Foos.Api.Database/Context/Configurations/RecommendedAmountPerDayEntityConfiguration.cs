using Foos.Api.Database.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foos.Api.Database.Context.Configurations
{
    public class RecommendedAmountPerDayEntityConfiguration : IEntityTypeConfiguration<RecommendedAmountPerDayEntity>
    {
        public void Configure(EntityTypeBuilder<RecommendedAmountPerDayEntity> builder)
        {
            
        }
    }
}
