using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.HistoricalData
{
    /// <summary>
    /// Configuracion de la tabla AuditEvent
    /// </summary>
    internal class AuditEventEntityTypeConfiguration
        : EntityTypeConfigurationBase<AuditEvent>
    {
        public override void Configure(EntityTypeBuilder<AuditEvent> builder)
        {
            /// <summary>
            /// Nombre de la tabla: "AuditEvents"
            /// </summary>
            builder.ToTable("AuditEvents");
            /// <summary>
            /// Relacion de uno a muchos con Worker
            /// </summary>
            builder.HasOne(x => x.Worker)
                .WithMany()
                .HasForeignKey(x => x.Id);
            builder.Ignore(x => x.Worker);
            base.Configure(builder);


        }
    }
}
