using AP_Theme_5.Domain.Entities.Configuration_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Contracts.ConfigurationData
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a un objeto del tipo Worker
    /// </summary>
    public interface IVariableRepository
    {
        /// <summary>
        /// Agrega una Variable al soporte de datos
        /// </summary>
        void AddVariable(Variable variable);
        /// <summary>
        /// Obtiene una Variable del soporte de datos a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        Variable? GetVariableById(Guid id);
        /// <summary>
        /// Obtiene todos las Variables del soporte de Datos
        /// </summary>
        public IEnumerable<Variable> GetAllVariables();
        /// <summary>
        /// Actualiza una Variable en el soporte de datos
        /// </summary>
        void UpdateVariable(Variable variable);
        /// <summary>
        /// Elimina una Variable del soporte de datos
        /// </summary>
        void DeleteVariable(Variable variable);
    }
}
