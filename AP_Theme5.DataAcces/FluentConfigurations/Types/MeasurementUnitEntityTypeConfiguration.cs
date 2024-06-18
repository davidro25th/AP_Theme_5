using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Types
{
    internal class MeasurementUnitEntityTypeConfiguration
        : EntityTypeConfigurationBase<AuditEvent>
    {
        public override void Configure(EntityTypeBuilder<AuditEvent> builder)
        {
            builder.ToTable("MeasurementUnits");
            base.Configure(builder);
            //TODO Finish MeasurementUnit
            //TODO Clean
        }
    }
}
