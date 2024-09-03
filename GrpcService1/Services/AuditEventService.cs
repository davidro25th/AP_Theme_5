using AP_Theme_5.Application.AuditEvent.Commands.CreateAuditEvent;
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
        private readonly IAuditEventRepository _auditEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AuditEventService(IAuditEventRepository auditEventRepository, IUnitOfWork unitOfWork)
        {
            _auditEventRepository = auditEventRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<AuditEventDTO> CreateAuditEvent(CreateAuditEventRequest request, ServerCallContext context)
        {
            var command = new CreateAuditEventCommand(
                request.Action,
                AP_Theme_5.Domain.Entities.Configuration_Data.Worker.Create( request.Worker.IdentityCard )              
                );
            var result = _mediator.Send(command).Result;
            return base.CreateAuditEvent(request, context);
        }

        public override Task<Empty> DeleteAuditEvent(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteAuditEvent(request, context); ;
        }
        public override Task<AuditEvents> GetAllAuditEvents(Empty request, ServerCallContext context)
        {
            return base.GetAllAuditEvents(request, context);
        }

        public override Task<NullableAuditEventDTO> GetAuditEvent(GetRequest request, ServerCallContext context)
        {
            return base.GetAuditEvent(request, context);
        }

        public override Task<Empty> UpdateAuditEvent(AuditEventDTO request, ServerCallContext context)
        {
            return base.UpdateAuditEvent(request, context);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuditEventService(IMediator _mediator, IMapper _mapper)
        {
            _mediator = _mediator;
            _mapper = _mapper;
        }


    }
}
