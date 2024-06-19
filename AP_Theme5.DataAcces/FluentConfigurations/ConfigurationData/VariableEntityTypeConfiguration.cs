using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData
{
    internal class VariableEntityTypeConfiguration
        : EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("Variables");
            //Relacion entre variable y unidad de medida
            //builder.HasOne(x => x.MeasurementUnit)
            //   .WithMany().HasForeignKey(x => x.MeasurementUnitId);
            //Considerando MeasurementUnit Value Object
            builder.OwnsOne(x => x.MeasurementUnit);
            base.Configure(builder);

        }
    }
}
