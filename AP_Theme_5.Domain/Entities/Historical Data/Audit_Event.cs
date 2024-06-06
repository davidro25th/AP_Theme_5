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
        #region Fields
        protected string action;
        protected DateTime ocurrence;
        protected Worker worker;
        #endregion

        #region Properties
        /// <summary>
        /// Accion que se va a realizar en el evento de auditoria
        /// </summary>
        public string Action {  get { return action; } }
        /// <summary>
        /// Fecha de ocurrencia del evento
        /// </summary>
        public DateTime Ocurrence { get {  return ocurrence; } }
        /// <summary>
        /// Operario que va a realizar la accion
        /// </summary>
        public Worker Worker { get { return worker; } }
        #endregion

        public Audit_Event(string action, DateTime ocurrence, Worker worker)
        {
            this.action = action;
            this.ocurrence = ocurrence;
            this.worker = worker;
        }
    }
}
