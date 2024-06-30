using AP_Theme_5.Domain.Entities.HistoricData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Contracts.HistoricalData
{
    public interface IAuditEventRepository
    {
        /// <summary>
        /// Agrega un AuditEvent al soporte de datos
        /// </summary>
        void AddAuditEvent(AuditEvent variable);
        /// <summary>
        /// Obtiene un AuditEvent del soporte de datos a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        AuditEvent? GetAuditEventById(Guid id);
        /// <summary>
        /// Obtiene todos las AuditEvent del soporte de Datos
        /// </summary>
        public IEnumerable<AuditEvent> GetAllAuditEvents();
        /// <summary>
        /// Actualiza una AuditEvent en el soporte de datos
        /// </summary>
        void UpdateAlarm(AuditEvent variable);
        /// <summary>
        /// Elimina una AuditEvent del soporte de datos
        /// </summary>
        void DeleteAuditEvent(AuditEvent variable);
    }
}
