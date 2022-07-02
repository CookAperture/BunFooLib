using Foos.Api.Database.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foos.Api.Database.Context.Configurations
{
    public class FooCategoryEntityConfiguration : IEntityTypeConfiguration<FooCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<FooCategoryEntity> builder)
        {
            
        }
    }
}
