using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.AuditEvent.Query.GetAuditEventByID
{
    public class GetAuditEventByIDQueryHandler : IQueryHandler<GetAuditEventByIDQuery, Domain.Entities.HistoricData.AuditEvent?>
    {
        private readonly IAuditEventRepository _auditEventRepository;

        public GetAuditEventByIDQueryHandler(IAuditEventRepository auditEventRepository)
        {
            _auditEventRepository = auditEventRepository;
        }

        public Task<Domain.Entities.HistoricData.AuditEvent?> Handle(GetAuditEventByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_auditEventRepository.GetAuditEventById(request.Id));
        }

    }
}
