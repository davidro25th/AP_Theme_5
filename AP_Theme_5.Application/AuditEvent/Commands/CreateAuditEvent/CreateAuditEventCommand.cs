using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.AuditEvent.Commands.CreateAuditEvent
{
    public record CreateAuditEventCommand(string action, Domain.Entities.Configuration_Data.Worker worker,
        DateTime ocurrence) : ICommand <AP_Theme_5.Domain.Entities.HistoricData.AuditEvent>;

}
