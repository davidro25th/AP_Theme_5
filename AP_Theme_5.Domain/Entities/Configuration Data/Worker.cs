using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
	/// <summary>
	/// Clase que representa al operario que va a realizar la accion 
	/// </summary>
    public class Worker
    {
		public Worker(string id)
		{
			Id = id;
		}

        #region Properties
		/// <summary>
		/// Primer nombre del operario
		/// </summary>
        public string Firstname { get; set; }
		/// <summary>
		/// Segundo nombre del operario
		/// </summary>
		public string Lastname { get; set; }
		/// <summary>
		/// Identificacion del operario
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Numero de telefono del operario
		/// </summary>
		public string PhoneNumber { get; set; }
        #endregion
    }
}
