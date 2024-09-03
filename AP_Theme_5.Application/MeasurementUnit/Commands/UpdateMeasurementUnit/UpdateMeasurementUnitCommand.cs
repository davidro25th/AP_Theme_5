using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.MeasurementUnit.Commands.UpdateMeasurementUnit
{
    public record UpdateMeasurementUnitCommand(Domain.Entities.Configuration_Data.MeasurementUnit measurementUnit) : ICommand;
    
}
