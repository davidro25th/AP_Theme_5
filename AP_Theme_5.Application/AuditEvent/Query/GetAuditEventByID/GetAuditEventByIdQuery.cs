using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.AuditEvent.Query.GetAuditEventByID
{
    public record GetAuditEventByIDQuery(Guid Id) : IQuery<Domain.Entities.HistoricData.AuditEvent?>;
}
