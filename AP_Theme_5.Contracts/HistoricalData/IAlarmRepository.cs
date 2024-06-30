using AP_Theme_5.Domain.Entities.HistoricData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Contracts.HistoricalData
{
    public interface IAlarmRepository
    {
        /// <summary>
        /// Agrega una Alarm al soporte de datos
        /// </summary>
        void AddAlarm(Alarm variable);
        /// <summary>
        /// Obtiene una Alarm del soporte de datos a partir de su identificador
        /// </summary>
        /// <param name="id"></param>
        Alarm? GetAlarmById(Guid id);
        /// <summary>
        /// Obtiene todos las Alarm del soporte de Datos
        /// </summary>
        public IEnumerable<Alarm> GetAllAlarms();
        /// <summary>
        /// Actualiza una Alarm en el soporte de datos
        /// </summary>
        void UpdateAlarm(Alarm variable);
        /// <summary>
        /// Elimina una Alarm del soporte de datos
        /// </summary>
        void DeleteAlarm(Alarm variable);
    }
}
