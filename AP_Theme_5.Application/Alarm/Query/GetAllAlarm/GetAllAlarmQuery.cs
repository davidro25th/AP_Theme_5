using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Alarm.Query.GetAllAlarm
{
    public record GetAllAlarmQuery() : IQuery<IEnumerable<Domain.Entities.HistoricData.Alarm>>;
    
}
