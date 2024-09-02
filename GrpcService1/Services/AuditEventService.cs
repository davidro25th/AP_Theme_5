using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

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

    }
}
