namespace AP_Theme_5.Domain.Common
{
    public abstract class Entity
    {
        #region Properties
        /// <summary>
        /// Propiedad para el Identificador
        /// </summary>
        public Guid Id { get; set; }
        #endregion

        /// <summary>
        /// Requerido por Entity Framework
        /// </summary>
        protected Entity() { }
        /// <summary>
        /// Asignacion de un ID a cada Clase
        /// </summary>
        protected Entity(Guid id)
        {
            Id = id;
        }

    }
}
