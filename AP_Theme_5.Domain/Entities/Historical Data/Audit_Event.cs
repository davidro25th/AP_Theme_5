using AP_Theme_5.Domain.Entities.Configuration_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.HistoricData
{
    public class Audit_Event
    {
        protected string action;
        protected DateTime ocurrence;
        protected Worker worker;

        public string Action {  get { return action; } }
        public DateTime Ocurrence { get {  return ocurrence; } }
        public Worker Worker { get { return worker; } }

        public Audit_Event(string action, DateTime ocurrence, Worker worker)
        {
            this.action = action;
            this.ocurrence = ocurrence;
            this.worker = worker;
        }
    }
}
