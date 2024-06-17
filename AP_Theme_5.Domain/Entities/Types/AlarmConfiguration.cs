namespace AP_Theme_5.Domain.Entities.Types
{
    public class AlarmConfiguration
    {
        #region Properties
        /// <summary>
        /// Fecha de ocurrencia de la alarma
        /// </summary>
        public DateTime IncidencenceDate { get; set; }
        /// <summary>
        /// Fecha de recuperacion de la alarma
        /// </summary>
        public DateTime RecoveryDate { get; set; }
        /// <summary>
        /// Nivel de prioridad de la alarma
        /// </summary>
        #endregion

        /// <summary>
        /// Constructor de Alarm Configuration
        /// </summary>
        public AlarmConfiguration(DateTime recoveryDate)
        {
            RecoveryDate = recoveryDate;
        }
    }
}
