using AP_Theme_5.Domain.Common;
using AP_Theme_5.Domain.Entities.Types;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    /// <summary>
    /// Clase que representa la variable medida 
    /// </summary>
    public class Variable : Entity
    {
        #region Properties
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Codigo asociado a la variable
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Unidad de medida de la variable
        /// </summary>
        public MeasurementUnit? MeasurementUnit { get; set; }
        #endregion

        /// <summary>
        /// Referencia uno a muchos con MeasurementUnit
        /// </summary>
        public Guid MeasurementUnitId { get; set; }

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected Variable() { }
        /// <summary>
        /// Constructor de la Clase Variable
        /// </summary>
        public Variable(string code)
        {
            Code = code;
        }
    }
}

