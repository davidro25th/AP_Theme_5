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
        public string IdentityCard { get; set; }
        /// <summary>
        /// Numero de telefono del operario
        /// </summary>
        public string? PhoneNumber { get; set; }
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
        private Worker(string identityCard)
        {

            IdentityCard = identityCard;
        }
        /// <summary>
        /// Metodo estatico de fabrica para la validacion del carne de identidad
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public static Worker Create(string identityCard)
        {
            if (identityCard.Length != 11)
            {
                return null;
            }
            if (!identityCard.All(char.IsDigit))
            {
                return null;
            }
            return new Worker(identityCard);
        }
    }


}
