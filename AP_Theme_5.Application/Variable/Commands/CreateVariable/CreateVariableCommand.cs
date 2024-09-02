using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.Variable.Commands.CreateVariable
{
    public record CreateVariableCommand(string name, string code, Domain.Types.MeasurementUnit measurementUnit) : ICommand <Domain.Entities.Configuration_Data.Variable>;

}
