using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.MeasurementUnit.Query.GetAllMeasurementUnit
{
    public record GetAllMeasurementUnitQuery() : IQuery<IEnumerable<Domain.Types.MeasurementUnit>>;
    
}
