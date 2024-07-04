using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Alarms
{
    /// <summary>
    /// Configuracion de la tabla Alarms
    /// </summary>
    public class AlarmEntityTypeConfiguration
        : EntityTypeConfigurationBase<Alarm>
    {
        public override void Configure(EntityTypeBuilder<Alarm> builder)
        {
            /// <summary>
            /// Nombre de la tabla: "Alarms"
            /// </summary>
            builder.ToTable("Alarms");
            /// <summary>
            /// Relacion entre Alarm y ALarmConfiguration como objeto de valor
            /// </summary> 
            builder.OwnsOne(x => x.AlarmConfiguration);
            base.Configure(builder);

        }
    }
}
