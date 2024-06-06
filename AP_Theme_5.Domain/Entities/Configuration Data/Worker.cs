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
			this.id = id;
		}
        #region Fields
        protected string firstname;
		protected string lastname;
		protected string id;
		protected string phone_number;
        #endregion

        #region Properties
		/// <summary>
		/// Primer nombre del operario
		/// </summary>
        public string Firstname { get { return firstname; } }
		/// <summary>
		/// Segundo nombre del operario
		/// </summary>
		public string Lastname { get { return lastname; } }
		/// <summary>
		/// Identificacion del operario
		/// </summary>
		protected string Id { get { return Id; } }
		/// <summary>
		/// Numero de telefono del operario
		/// </summary>
		public string PhoneNumber { get { return phone_number; } }
        #endregion
    }
}
