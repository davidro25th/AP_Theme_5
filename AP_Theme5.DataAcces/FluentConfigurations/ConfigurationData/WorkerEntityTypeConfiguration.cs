using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData
{
    internal class WorkerEntityTypeConfiguration
        : EntityTypeConfigurationBase<Worker>
    {
        public override void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Workers");
            //no se si lo lleva***
            builder.HasMany(x => x.AuditEvent)
                .WithOne(x => x.Worker);
            base.Configure(builder);

            //TODO Finish Worker Configuration
            //TODO Clean
        }
    }
}
