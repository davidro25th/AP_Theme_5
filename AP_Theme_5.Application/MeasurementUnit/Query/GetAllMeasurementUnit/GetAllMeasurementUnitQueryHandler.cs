using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.Types;
using MediatR;

namespace AP_Theme_5.Application.MeasurementUnit.Query.GetAllMeasurementUnit
{
    public class GetAllMeasurementUnitQueryHandler : IQueryHandler<GetAllMeasurementUnitQuery, IEnumerable<Domain.Types.MeasurementUnit>>
    {
        private readonly IMeasurementUnitRepository _measurementUnitrepository;
        public GetAllMeasurementUnitQueryHandler( IMeasurementUnitRepository measurementUnitRepository )
        {
            _measurementUnitrepository = measurementUnitRepository; 
        }

        Task<IEnumerable<Domain.Types.MeasurementUnit>> IRequestHandler<GetAllMeasurementUnitQuery, IEnumerable<Domain.Types.MeasurementUnit>>.Handle(GetAllMeasurementUnitQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_measurementUnitrepository.GetAllMeasurementUnits());
        }
    }
}
