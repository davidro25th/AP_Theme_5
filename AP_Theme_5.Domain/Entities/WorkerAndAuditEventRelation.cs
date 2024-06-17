using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Common;

namespace AP_Theme_5.Domain.Entities
{
    public class WorkerAndAuditEventRelation:Entity
    {
        public int WorkerId { get; set; }
        public int AuditEventId { get; set; }

    }
}
