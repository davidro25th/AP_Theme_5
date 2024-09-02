using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.MeasurementUnit.Query.GetMeasurementUnitByID
{
    public record GetMeasurementUnitByIDQuery(Guid Id) : IQuery<Domain.Types.MeasurementUnit?>;
}
