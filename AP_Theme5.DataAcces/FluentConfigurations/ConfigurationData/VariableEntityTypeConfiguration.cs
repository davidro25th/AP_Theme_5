using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData
{
    internal class VariableEntityTypeConfiguration
        :EntityTypeConfigurationBase<Variable>
    {
        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            builder.ToTable("Variables");
            builder.HasOne(x => x.MeasurementUnit)
                .WithMany().HasForeignKey(x => x.MeasurementUnitId);
            base.Configure(builder);
            //TODO Finish Worker Configuration
            //TODO Clean
        }
    }
}
