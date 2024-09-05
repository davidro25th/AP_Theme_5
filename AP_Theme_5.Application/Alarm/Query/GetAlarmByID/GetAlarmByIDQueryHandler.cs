using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Alarm.Query.GetAlarmByID
{
    public class GetAlarmByIDQueryHandler : IQueryHandler<GetAlarmByIDQuery, Domain.Entities.HistoricData.Alarm?>
    {
        private readonly IAlarmRepository _alarmRepository;

        public GetAlarmByIDQueryHandler(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public Task<Domain.Entities.HistoricData.Alarm?> Handle(GetAlarmByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_alarmRepository.GetAlarmById(request.Id));
        }

    }
}
