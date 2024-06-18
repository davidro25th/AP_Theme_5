using AP_Theme_5.Domain.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa el evento de auditoria 
    /// </summary>
    public class AuditEvent : Entity
    {

        #region Properties

        /// <summary>
        /// Accion que se va a realizar en el evento de auditoria
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Fecha de ocurrencia del evento
        /// </summary>
        public DateTime Ocurrence { get; set; }
        /// <summary>
        /// Operario que va a realizar la accion
        /// </summary>
        /// <summary>
        /// Relacion uno a muchos entre AuditEvent y Worker
        /// </summary>
        public Worker Worker { get; set; }
        public Guid WorkerId { get; set; }
        #endregion

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected AuditEvent() { }
        /// <summary>
        /// Constructor de la clase AuditEvent
        /// </summary>
        public AuditEvent(string action, Worker worker)
        {
            Action = action;
            Worker = worker;
            WorkerId = worker.Id;
        }
    }
}
