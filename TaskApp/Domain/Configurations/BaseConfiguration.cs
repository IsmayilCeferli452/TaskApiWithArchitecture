using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    internal class BaseConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(m => m.SoftDeleted).HasDefaultValue(false);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.Now);
        }
    }
}
