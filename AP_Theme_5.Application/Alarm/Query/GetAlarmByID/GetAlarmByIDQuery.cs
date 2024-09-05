using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Entities.HistoricData;


namespace AP_Theme_5.Application.Alarm.Query.GetAlarmByID
{
    public record GetAlarmByIDQuery(Guid Id) : IQuery<Domain.Entities.HistoricData.Alarm?>;
}
