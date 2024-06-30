using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.Common;
using AP_Theme_5.Domain.Entities.HistoricData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.Repositories.HistoricalData
{
    public class AlarmRepository :
        RepositoryBase, IAlarmRepository
    {
        public AlarmRepository(ApplicationContext _context) : base(_context)
        {
        }

        public void AddAlarm(Alarm alarm)
        {
            _context.Alarms.Add(alarm);
        }

        public void DeleteAlarm(Alarm variable)
        {
            _context.Alarms.Remove(variable);
        }

        public Alarm? GetAlarmById(Guid id)
        {
            return _context.Alarms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Alarm> GetAllAlarms()
        {
            return _context.Alarms.ToList();
        }

        public void UpdateAlarm(Alarm variable)
        {
            _context.Alarms.Update(variable);
        }
    }
}
