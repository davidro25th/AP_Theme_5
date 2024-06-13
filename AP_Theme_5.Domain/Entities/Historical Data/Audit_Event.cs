using AP_Theme_5.Domain.Entities.Configuration_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa el evento de auditoria 
    /// </summary>
    public class Audit_Event
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

        public Audit_Event(string action, DateTime ocurrence, Worker worker)
        {
            Action = action;
            Ocurrence = ocurrence;
            Worker = worker;
        }
    }
}
