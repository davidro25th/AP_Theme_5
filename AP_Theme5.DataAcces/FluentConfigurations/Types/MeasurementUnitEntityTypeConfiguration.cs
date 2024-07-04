using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Types
{
    /// <summary>
    /// Configuracion de la tabla MeasurementUnits
    /// </summary>
    internal class MeasurementUnitEntityTypeConfiguration : EntityTypeConfigurationBase<MeasurementUnit>
    {
        public override void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            /// <summary>
            /// Nombre de la tabla: "MeasurementUnits"
            /// </summary>
            builder.ToTable("MeasurementUnits");
            builder.Ignore(x => x.Variable);
            /// <summary>
            /// Configuracion De la propiedad UnitName Como Requerida
            /// </summary>
            //builder.Property(x => x.UnitName).IsRequired();
            /// <summary>
            /// Configuracion De la propiedad UnitName Como Unica
            /// </summary>
            //builder.HasIndex(x => x.UnitName).IsUnique();
            base.Configure(builder);

        }
    }
}
