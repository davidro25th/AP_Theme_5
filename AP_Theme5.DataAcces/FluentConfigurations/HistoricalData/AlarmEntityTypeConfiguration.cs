using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.FluentConfigurations.Alarms
{
    public class AlarmEntityTypeConfiguration
        : IEntityTypeConfiguration<Alarm>
    {
        public override void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.ToTable("Alarms");
            //TODO Finish Alarm Configuration
            //TODO Clean
        }
    }
}
