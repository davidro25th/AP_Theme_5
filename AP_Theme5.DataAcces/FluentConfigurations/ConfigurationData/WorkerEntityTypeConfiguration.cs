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
            builder.Property(x => x.IdentityCard).
                /// Conversion de arreglo de enteros a Int
                HasConversion(
                c => String.Join("", c),
                s => s.Select(i => Convert.ToInt32(i)).ToArray());
            builder.Property(x => x.PhoneNumber).
            HasConversion(
            c => String.Join("", c),
            s => s.Select(i => Convert.ToInt32(i)).ToArray());
            base.Configure(builder);

            //TODO Finish Worker Configuration
            //TODO Clean
        }
    }
}
