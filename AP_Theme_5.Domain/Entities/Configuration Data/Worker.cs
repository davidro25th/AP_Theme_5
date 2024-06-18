using AP_Theme_5.Domain.Common;
using AP_Theme_5.Domain.Entities.HistoricData;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    /// <summary>
    /// Clase que representa al operario que va a realizar la accion 
    /// </summary>
    public class Worker : Entity
    {
        #region Properties
        /// <summary>
        /// Primer nombre del operario
        /// </summary>
        public string? Firstname { get; set; }
        /// <summary>
        /// Segundo nombre del operario
        /// </summary>
        public string? Lastname { get; set; }
        /// <summary>
        /// Identificacion del operario
        /// </summary>
        public int[] IdentityCard { get; set; }
        /// <summary>
        /// Numero de telefono del operario
        /// </summary>
        public int[]? PhoneNumber { get; set; }
        #endregion

        /// <summary>
        /// Relacion uno a muchos entre Worker y AuditEvent 
        /// <summary>
        public List<AuditEvent> AuditEvent { get; set; }

        /// <summary>
        /// Constructor Requerido por Entity Framework
        /// </summary>
        protected Worker() { }
        /// <summary>
        /// Constructor de la clase Worker
        /// </summary>
        public Worker(int[] identityCard)
        {
            IdentityCard = identityCard;
        }
    }


}
