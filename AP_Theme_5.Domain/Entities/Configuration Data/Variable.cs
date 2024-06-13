using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Entities.Utilities;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    /// <summary>
    /// Clase que representa la variable medida 
    /// </summary>
    public class Variable
    {
		public Variable(string code)
		{
			Code = code;
		}


        #region Properties
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name { get; set; }
		/// <summary>
		/// Codigo asociado a la variable
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// Unidad de medida de la variable
		/// </summary>
        public Measurement_Unit Measurement_Units {  get; set; }
        #endregion


    }
}
