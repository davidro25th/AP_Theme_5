using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.HistoricalData
{
    internal class AuditEventEntityTypeConfiguration
        : EntityTypeConfigurationBase<AuditEvent>
    {
        public override void Configure(EntityTypeBuilder<AuditEvent> builder)
        {
            //Relacion entre AuditEvent y Worker
            builder.ToTable("AuditEvents");
            builder.HasOne(x => x.Worker).WithMany().HasForeignKey(x => x.WorkerId);
            base.Configure(builder);


        }
    }
}
