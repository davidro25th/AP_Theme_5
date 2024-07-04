using AP_Theme_5.Domain.Common;
using AP_Theme_5.Domain.ValueObjects;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    /// <summary>
    /// Clase que representa la alarma del sistema
    /// </summary>
    public class Alarm : Entity
    {
        #region Properties
        public Guid Id { get; set; }
        /// <summary>
        /// Fecha de ocurrencia de la alarma
        /// </summary>
        public DateTime IncidencenceDate { get; private set; }
        /// <summary>
        /// Fecha de recuperacion de la alarma
        /// </summary>
        public DateTime RecoveryDate { get; private set; }
        /// <summary>
        /// Nivel de prioridad de la alarma
        /// </summary>
        public AlarmConfiguration AlarmConfiguration { get; set; }
        #endregion

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected Alarm() { }
        /// <summary>
        /// Constructor para la Clase Alarm
        /// </summary>
        public Alarm(AlarmConfiguration alarmConfiguration)
        {
            AlarmConfiguration = alarmConfiguration;
            IncidencenceDate = DateTime.Now;
        }
        /// <summary>
        /// Metodo para establecer la fecha de Recuperacion de la Alarma
        /// </summary>
        public void Recovery()
        {
            RecoveryDate = DateTime.Now;
        }

    }
}
