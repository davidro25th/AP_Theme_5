using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Alarm.Commands.UpdateAlarm
{
    public class UpdateAlarmCommandHandler :
        ICommandHandler<UpdateAlarmCommand>
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAlarmCommandHandler(IAlarmRepository alarmRepository, IUnitOfWork unitOfWork)
        {
            _alarmRepository = alarmRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle( UpdateAlarmCommand request, CancellationToken cancellationToken)
        {
            _alarmRepository.UpdateAlarm(request.alarm);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

        
    }
}
