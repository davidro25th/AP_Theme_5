using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class AlarmService : Alarm.AlarmBase
    {
        private readonly IAlarmRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AlarmService(IAlarmRepository alarmRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = alarmRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<AlarmDTO> CreateAlarm(CreateAlarmRequest request, ServerCallContext context)
        {
            return base.CreateAlarm(request, context);
        }
        public override Task<NullableAlarmDTO> GetAlarm(GetRequest request, ServerCallContext context)
        {
            return base.GetAlarm(request, context);
        }
        public override Task<Alarms> GetAllAlarms(Empty request, ServerCallContext context)
        {
            return base.GetAllAlarms(request, context);
        }
        public override Task<Empty> UpdateAlarm(AlarmDTO request, ServerCallContext context)
        {
            return base.UpdateAlarm(request, context);
        }
        public override Task<Empty> DeleteAlarm(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteAlarm(request, context);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AlarmService(IMediator _mediator, IMapper _mapper)
        {
            _mediator = _mediator;
            _mapper = _mapper;
        }

  

    }
}
