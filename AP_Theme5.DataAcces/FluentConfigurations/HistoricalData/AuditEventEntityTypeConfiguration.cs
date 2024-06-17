using AP_Theme_5.DataAcces.FluentConfigurations.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.FluentConfigurations.HistoricalData
{
    internal class AuditEventEntityTypeConfiguration
        : EntityTypeConfigurationBase<AuditEvent>
    {
        public override void Configure(EntityTypeBuilder<AuditEvent> builder)
        {
            builder.ToTable("AuditEvents");
            base.Configure(builder);

        }
    }
}
