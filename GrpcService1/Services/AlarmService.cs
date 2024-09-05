using AP_Theme_5.Application.Alarm.Commands.CreateAlarm;
using AP_Theme_5.Application.Alarm.Query.GetAlarmByID;
using AP_Theme_5.Application.Alarm.Query.GetAllAlarm;
using AP_Theme_5.Application.Alarm.Commands.UpdateAlarm;
using AP_Theme_5.Application.Alarm.Commands.DeleteAlarm;
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


        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AlarmService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IAlarmRepository _alarmRepository;


        public override Task<AlarmDTO> CreateAlarm(CreateAlarmRequest request, ServerCallContext context)
        {
            var command = new CreateAlarmCommand(
                new AP_Theme_5.Domain.ValueObjects.AlarmConfiguration(
                    request.Alarmconfiguration.Outofrange,
                    new AP_Theme_5.Domain.Entities.Configuration_Data.Variable( 
                        request.Alarmconfiguration.Alarmvariable.Code,
                        request.Alarmconfiguration.Alarmvariable.Name,
                        new AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit( 
                            request.Alarmconfiguration.Alarmvariable.Measurementunit.Unitname,
                            request.Alarmconfiguration.Alarmvariable.Measurementunit.Unittype
                            )
                        )
                    )

                );
            var result = _mediator.Send(command).Result;
            return base.CreateAlarm(request, context);
        }
        public override Task<NullableAlarmDTO> GetAlarm(GetRequest request, ServerCallContext context)
        {
            var query = new GetAlarmByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableAlarmDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableAlarmDTO() { Alarm = _mapper.Map<AlarmDTO>(result) });
        }
        public override Task<Alarms> GetAllAlarms(Empty request, ServerCallContext context)
        {
            var query = new GetAllAlarmQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de alarmas al mensaje de lista de DTOs de alarmas.
            var motorcyclesDTOs = new Alarms();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<AlarmDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }
        public override Task<Empty> UpdateAlarm(AlarmDTO request, ServerCallContext context)
        {
            var command = new UpdateAlarmCommand(_mapper.Map<AP_Theme_5.Domain.Entities.HistoricData.Alarm>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteAlarm(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteAlarmCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }   
    }
}
