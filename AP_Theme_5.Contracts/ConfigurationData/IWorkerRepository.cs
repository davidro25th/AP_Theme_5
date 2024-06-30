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
    public interface IWorkerRepository
    {
        /// <summary>
        /// Agrega un Worker al soporte de datos
        /// </summary>
        /// <param name="worker"></param>
        void AddWorker(Worker worker); 
        /// <summary>
        /// Obtiene un Worker del soporte de datos a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Worker? GetWorkerById(Guid id);
        /// <summary>
        /// Obtiene todos los Workers del soporte de Datos
        /// </summary>
        public IEnumerable<Worker> GetAllWorkers();
        /// <summary>
        /// Actualiza un Worker en el soporte de datos
        /// </summary>
        /// <param name="worker"></param>
        void UpdateWorker(Worker worker);
        /// <summary>
        /// Elimina un Worker del soporte de datos
        /// </summary>
        /// <param name="worker"></param>
        void DeleteWorker(Worker worker);
    }
}
