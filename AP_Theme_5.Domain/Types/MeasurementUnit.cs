using AP_Theme_5.Domain.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Domain.Entities.Types
{
    /// <summary>
    /// Unidades de medida de la variable
    /// </summary>
    public class MeasurementUnit : Entity
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
        /// </summary>
        public List<Variable> Variable { get; set; }

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
    }
}
