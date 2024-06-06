using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
	/// <summary>
	/// Clase que representa la variable medida 
	/// </summary>
    public class Variable
    {
		public Variable(string code)
		{
			this.code = code;
		}
		#region Fields 
		protected string name;
		protected string code;
		protected Measurement_Unit measurement_Unit;
        #endregion

        #region Properties
        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name { get { return name; } }
		/// <summary>
		/// Codigo asociado a la variable
		/// </summary>
		public string Code { get { return code; } }
		/// <summary>
		/// Unidad de medida de la variable
		/// </summary>
        public Measurement_Unit Measurement_Units => measurement_Unit;
        #endregion


    }
}
