using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Alarm.Commands.DeleteAlarm
{
    public class DeleteAlarmCommandHandler : ICommandHandler<DeleteAlarmCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAlarmRepository _alarmRepository;

        public DeleteAlarmCommandHandler(IUnitOfWork unitOfWork, IAlarmRepository alarmRepository)
        {
            _unitOfWork = unitOfWork;
            _alarmRepository = alarmRepository;
        }

        public Task Handle(DeleteAlarmCommand request, CancellationToken cancellationToken) 
        {
            var AlarmToDelete = _alarmRepository.GetAlarmById(request.id);
            if (AlarmToDelete == null)
               return Task.CompletedTask;
            
            _alarmRepository.DeleteAlarm(AlarmToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }

    

}
