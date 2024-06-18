using AP_Theme_5.Domain.Entities.Common
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.Types;

namespace AP_Theme_5.Domain.ValueObjects
{
    public class AlarmConfiguration : ValueObject
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
        public Variable AlarmVariable { get; set; }
        /// <summary>
        /// Datos de configuracion de la Alarma
        /// </summary>
        #endregion

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected AlarmConfiguration() { }

        /// <summary>
        /// Constructor para la clase AlarmConfiguration
        /// </summary>
        public AlarmConfiguration(double out_of_range, Variable alarmVariable)
        {
            OutOfRange = out_of_range;
            AlarmVariable = alarmVariable;
        }

        /// <summary>
        /// Implementacion de GetEqualityComponents en AlarmConfiguration
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OutOfRange;
            yield return Priority;
            yield return AlarmVariable;
        }


    }
}

