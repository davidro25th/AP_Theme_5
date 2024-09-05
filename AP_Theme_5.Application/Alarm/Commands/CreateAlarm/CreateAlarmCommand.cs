using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Entities.HistoricData;

namespace AP_Theme_5.Application.Alarm.Commands.CreateAlarm
{
    public record CreateAlarmCommand(Domain.ValueObjects.AlarmConfiguration alarmConfiguration) : ICommand <Domain.Entities.HistoricData.Alarm>;

}
