using AP_Theme_5.Application.AuditEvent.Commands.CreateAuditEvent;
using AP_Theme_5.Application.AuditEvent.Query.GetAuditEventByID;
using AP_Theme_5.Application.AuditEvent.Query.GetAllAuditEvent;
using AP_Theme_5.Application.AuditEvent.Commands.UpdateAuditEvent;
using AP_Theme_5.Application.AuditEvent.Commands.DeleteAuditEvent;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class AuditEventService :AuditEvent.AuditEventBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuditEventService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IAuditEventRepository _auditEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AuditEventService(IAuditEventRepository auditEventRepository, IUnitOfWork unitOfWork)
        {
            _auditEventRepository = auditEventRepository;
            _unitOfWork = unitOfWork;
        }

        public AuditEventService(IAuditEventRepository auditEventRepository, IMapper mapper)
        {
            _auditEventRepository = auditEventRepository;
            _mapper = mapper;
        }


        public override Task<AuditEventDTO> CreateAuditEvent(CreateAuditEventRequest request, ServerCallContext context)
        {
            var command = new CreateAuditEventCommand(
                request.Action,
                AP_Theme_5.Domain.Entities.Configuration_Data.Worker.Create( request.Worker.IdentityCard )              
                );
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<AuditEventDTO>(result));
        }

        public override Task<Empty> DeleteAuditEvent(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteAuditEventCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<AuditEvents> GetAllAuditEvents(Empty request, ServerCallContext context)
        {
            var query = new GetAllAuditEventQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de motocicletas al mensaje de lista de DTOs de motocicletas.
            var motorcyclesDTOs = new AuditEvents();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<AuditEventDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }

        public override Task<NullableAuditEventDTO> GetAuditEvent(GetRequest request, ServerCallContext context)
        {
            var query = new GetAuditEventByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableAuditEventDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableAuditEventDTO() { Auditevent = _mapper.Map<AuditEventDTO>(result) });
        }

        public override Task<Empty> UpdateAuditEvent(AuditEventDTO request, ServerCallContext context)
        {
            var command = new UpdateAuditEventCommand(_mapper.Map<AP_Theme_5.Domain.Entities.HistoricData.AuditEvent>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        


    }
}
