using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Contracts.ConfigurationData
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a un objeto del tipo Variable
    /// </summary>
    public interface IVariableRepository
    {
        /// <summary>
        /// Agrega una variable al soporte de datos
        /// </summary>
        /// <param name="variable"></param>
        void AddVariable(Variable variable);
        /// <summary>
        /// Obtiene una Variable del soporte de datos a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        Variable? GetVariableById(Guid id);
        /// <summary>
        /// Obtiene todas las variables del soporte de datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Variable> GetAllVariables();
        /// <summary>
        /// Actualiza una variable en el soporte de datos
        /// </summary>
        /// <param name="variable"></param>
        void UpdateVariable(Variable variable);
        /// <summary>
        /// Elimina una variable del soporte de datos
        /// </summary>
        /// <param name="variable"></param>
        void DeleteVariable(Variable variable);
    }
}
