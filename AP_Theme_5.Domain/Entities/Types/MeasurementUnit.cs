namespace AP_Theme_5.Domain.Entities.Types
{
    /// <summary>
    /// Unidades de medida de la variable
    /// </summary>
    public class MeasurementUnit
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
        /// Constructor para la unidad de Medida
        /// </summary>
        /// <param name="UnitName"></param>
        public MeasurementUnit(string UnitName)
        {
            this.UnitName = UnitName;
        }
    }
}
