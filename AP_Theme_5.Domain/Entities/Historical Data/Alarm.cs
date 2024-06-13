using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa la alarma del sistema
    /// </summary>
    public class Alarm
    {
        #region Properties
        /// <summary>
        /// Fecha de ocurrencia de la alarma
        /// </summary>
        public DateTime Incidencedate { get; set; }
        /// <summary>
        /// Fecha de recuperacion de la alarma
        /// </summary>
        public DateTime Recoverydate { get; set; }
        /// <summary>
        /// Nivel de prioridad de la alarma
        /// </summary>
        public Priority Priority { get; set; }
        /// <summary>
        /// Valor fuera de rango
        /// </summary>
        public double OutOfRange { get; set; }
        /// <summary>
        /// Variable asociada a la alarma
        /// </summary>
        public Variable AlarmVariable { get; set; }
        #endregion

        public Alarm(double out_of_range )
        {
            OutOfRange = out_of_range;
        }

    }
}
