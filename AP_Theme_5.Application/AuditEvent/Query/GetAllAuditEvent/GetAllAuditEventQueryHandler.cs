using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using MediatR;

namespace AP_Theme_5.Application.AuditEvent.Query.GetAllAuditEvent
{
    public class GetAllAuditEventQueryHandler : IQueryHandler<GetAllAuditEventQuery, IEnumerable<Domain.Entities.HistoricData.AuditEvent>>
    {
        private readonly IAuditEventRepository _auditEventrepository;
        public GetAllAuditEventQueryHandler( IAuditEventRepository auditEventRepository )
        {
            _auditEventrepository = auditEventRepository; 
        }

        Task<IEnumerable<Domain.Entities.HistoricData.AuditEvent>> IRequestHandler<GetAllAuditEventQuery, IEnumerable<Domain.Entities.HistoricData.AuditEvent>>.Handle(GetAllAuditEventQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auditEventrepository.GetAllAuditEvents());
        }
    }
}
