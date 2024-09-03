using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Application.Worker.Commands.CreateWorker
{
    public record CreateWorkerCommand(string identityCard) : ICommand <AP_Theme_5.Domain.Entities.Configuration_Data.Worker>;

}
