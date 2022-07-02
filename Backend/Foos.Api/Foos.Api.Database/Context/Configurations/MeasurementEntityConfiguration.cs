using Foos.Api.Database.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foos.Api.Database.Context.Configurations
{
    public class MeasurementEntityConfiguration : IEntityTypeConfiguration<MeasurementEntity>
    {
        public void Configure(EntityTypeBuilder<MeasurementEntity> builder)
        {
            
        }
    }
}
