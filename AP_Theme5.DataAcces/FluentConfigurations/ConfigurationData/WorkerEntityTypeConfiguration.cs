using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData
{
    /// <summary>
    /// Configuracion de la tabla Workers
    /// </summary>
    internal class WorkerEntityTypeConfiguration
        : EntityTypeConfigurationBase<Worker>
    {
        public override void Configure(EntityTypeBuilder<Worker> builder)
        {
            /// <summary>
            /// Nombre de la tabla: "Workers"
            /// </summary>
            builder.ToTable("Workers");
            base.Configure(builder);
        }
    }
}
