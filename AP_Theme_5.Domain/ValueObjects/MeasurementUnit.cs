using AP_Theme_5.Domain.Entities.Common;

namespace AP_Theme_5.Domain.ValueObjects
{
    /// <summary>
    /// Unidades de medida de la variable
    /// </summary>
    public class MeasurementUnit : ValueObject
    {
        #region Properties
        /// <summary>
        /// Tipo de Unidad de Medida (Temperatura, Presion, etc.)
        /// </summary>
        public string? UnitType { get; set; }
        /// <summary>
        /// Nombre de la Unidad de Medida (Kelvin, Bar, Libra)
        /// </summary>
        public string UnitName { get; set; }
        #endregion
        /// <summary>
        /// Referencia uno a muchos con Variable
        /// Por ahora considerandose Value object no necesita la referencia
        /// </summary>
        //public List<Variable> Variable { get; set; }

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected MeasurementUnit() { }
        /// <summary>
        /// Constructor para la unidad de Medida
        /// </summary>
        /// <param name="UnitName"></param>
        public MeasurementUnit(string UnitName)
        {
            this.UnitName = UnitName;
        }
        /// <summary>
        /// Implementacion de GetEqualityComponents en AlarmConfiguration
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UnitType; 
            yield return UnitName;
        }
    }
}
