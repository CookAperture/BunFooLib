using Foos.Api.Database.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foos.Api.Database.Context.Configurations
{
    public class FooEntityConfiguration : IEntityTypeConfiguration<FooEntity>
    {
        public void Configure(EntityTypeBuilder<FooEntity> builder)
        {
            
        }
    }
}
