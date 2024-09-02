using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Worker.Commands.DeleteWorker
{
    public record DeleteWorkerCommand(Guid id) : ICommand;
}
