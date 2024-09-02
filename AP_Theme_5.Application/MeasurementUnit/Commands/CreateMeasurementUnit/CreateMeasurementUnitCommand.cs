using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.MeasurementUnit.Commands.CreateMeasurementUnit
{
    public record CreateMeasurementUnitCommand(string unitType, string unitName) : ICommand <AP_Theme_5.Domain.Types.MeasurementUnit>;

}
