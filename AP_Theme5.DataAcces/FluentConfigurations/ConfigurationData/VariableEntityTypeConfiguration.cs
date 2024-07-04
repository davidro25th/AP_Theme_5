using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData
{
    /// <summary>
    /// Configuracion de la tabla Variables
    /// </summary>
    internal class VariableEntityTypeConfiguration
        : EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            /// <summary>
            /// Nombre de la tabla: "Variables"
            /// </summary>
            builder.ToTable("Variables");
            /// <summary>
            /// Relacion de uno a muchos con MeasurementUnit
            /// </summary>
            builder.HasOne(x => x.MeasurementUnit)
                .WithMany()
                .HasForeignKey(x => x.MeasurementUnitId);
            builder.Ignore(x => x.MeasurementUnit);
            base.Configure(builder);

        }
    }
}
