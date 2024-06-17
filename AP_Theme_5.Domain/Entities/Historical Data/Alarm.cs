using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.Types;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa la alarma del sistema
    /// </summary>
    public class Alarm
    {
        #region Properties
        public Priority Priority { get; set; }
        /// <summary>
        /// Valor fuera de rango
        /// </summary>
        public double OutOfRange { get; set; }
        /// <summary>
        /// Variable asociada a la alarma
        /// </summary>
        public Variable? AlarmVariable { get; set; }
        /// <summary>
        /// Datos de configuracion de la Alarma
        /// </summary>
        public AlarmConfiguration AlarmConfiguration { get; set; }
        #endregion

        /// <summary>
        /// Constructor para la Clase Alarm
        /// </summary>
        public Alarm(double out_of_range, AlarmConfiguration alarmConfiguration)
        {
            OutOfRange = out_of_range;
            AlarmConfiguration = alarmConfiguration;
        }

    }
}
