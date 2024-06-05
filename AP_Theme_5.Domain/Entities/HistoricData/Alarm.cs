using AP_Theme_5.Domain.Entities.Configuration_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    public class Alarm
    {
        public DateTime Incidencedate { get; set; }
        public DateTime Recoverydate { get; set; }
        public Priority Priority { get; set; }
        public double OutOfRange { get; set; }
        public Variable AlarmVariable { get; set; }

    }
}
