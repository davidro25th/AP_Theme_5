using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.Repositories.HistoricalData
{
    public class AuditEventRepository :
        RepositoryBase, IAuditEventRepository
    {
        public AuditEventRepository(ApplicationContext _context) : base(_context)
        {
        }

        public void AddAuditEvent(AuditEvent auditEvent)
        {
            _context.AuditEvents.Add(auditEvent);
        }

        public void DeleteAuditEvent(AuditEvent auditEvent)
        {
            _context.AuditEvents.Remove(auditEvent);
        }

        public IEnumerable<AuditEvent> GetAllAuditEvents()
        {
            return _context.AuditEvents.ToList();
        }

        public AuditEvent? GetAuditEventById(Guid id)
        {
            return _context.AuditEvents.FirstOrDefault(x => x.Id == id);
        }
        
        public void UpdateAlarm(AuditEvent auditEvent)
        {
            _context.AuditEvents.Update(auditEvent);
        }
    }
}

