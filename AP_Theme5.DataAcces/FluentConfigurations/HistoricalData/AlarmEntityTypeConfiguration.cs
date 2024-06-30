using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Alarms
{
    public class AlarmEntityTypeConfiguration
        : EntityTypeConfigurationBase<Alarm>
    {
        public override void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.ToTable("Alarms");
            // Relacion entre Alarm y ALarmConfiguration (Value Object)
            builder.OwnsOne(x => x.AlarmConfiguration);
            base.Configure(builder);

        }
    }
}
