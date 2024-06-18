using AP_Theme_5.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Common
{
    public abstract class EntityTypeConfigurationBase<T>
        : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }


    }
}
