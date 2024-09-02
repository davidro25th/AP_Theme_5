using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using MediatR;

namespace AP_Theme_5.Application.Alarm.Query.GetAllAlarm
{
    public class GetAllAlarmQueryHandler : IQueryHandler<GetAllAlarmQuery, IEnumerable<Domain.Entities.HistoricData.Alarm>>
    {
        private readonly IAlarmRepository _alarmrepository;
        public GetAllAlarmQueryHandler( IAlarmRepository alarmRepository )
        {
            _alarmrepository = alarmRepository; 
        }

        Task<IEnumerable<Domain.Entities.HistoricData.Alarm>> IRequestHandler<GetAllAlarmQuery, IEnumerable<Domain.Entities.HistoricData.Alarm>>.Handle(GetAllAlarmQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_alarmrepository.GetAllAlarms());
        }
    }
}
