using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Alarm.Commands.CreateAlarm
{
    public class CreateAlarmCommandHandler :
        ICommandHandler<CreateAlarmCommand, Domain.Entities.HistoricData.Alarm>
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAlarmCommandHandler(IAlarmRepository alarmRepository, IUnitOfWork unitOfWork)
        {
            _alarmRepository = alarmRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.Entities.HistoricData.Alarm> Handle(CreateAlarmCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.HistoricData.Alarm result = new Domain.Entities.HistoricData.Alarm( request.alarmConfiguration );
            _alarmRepository.AddAlarm( result );
            _unitOfWork.SaveChanges();

            return Task.FromResult( result );
        }


    }

    

}
