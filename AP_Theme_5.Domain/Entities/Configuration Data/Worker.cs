namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    /// <summary>
    /// Clase que representa al operario que va a realizar la accion 
    /// </summary>
    public class Worker
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
        public short[] IdentityCard { get; set; }
        /// <summary>
        /// Numero de telefono del operario
        /// </summary>
        public short[]? PhoneNumber { get; set; }
        #endregion

        /// <summary>
        /// Constructor de la clase Worker
        /// </summary>
        public Worker(short[] identityCard)
        {
            IdentityCard = identityCard;
        }
    }


}
