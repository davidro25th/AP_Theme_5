using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa el evento de auditoria 
    /// </summary>
    public class AuditEvent
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
        public Worker Worker { get; set; }
        #endregion
        /// <summary>
        /// Constructor de la clase AuditEvent
        /// </summary>
        /// <param name="action"></param>
        /// <param name="worker"></param>
        public AuditEvent(string action, Worker worker)
        {
            Action = action;
            Worker = worker;
        }
    }
}
