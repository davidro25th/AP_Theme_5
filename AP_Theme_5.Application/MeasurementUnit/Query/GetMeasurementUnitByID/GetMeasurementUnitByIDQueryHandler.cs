using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.MeasurementUnit.Query.GetMeasurementUnitByID
{
    public class GetMeasurementUnitByIDQueryHandler : IQueryHandler<GetMeasurementUnitByIDQuery, Domain.Types.MeasurementUnit?>
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;

        public GetMeasurementUnitByIDQueryHandler(IMeasurementUnitRepository measurementUnitRepository)
        {
            _measurementUnitRepository = measurementUnitRepository;
        }

        public Task<Domain.Types.MeasurementUnit?> Handle(GetMeasurementUnitByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_measurementUnitRepository.GetMeasurementUnitById(request.Id));
        }

    }
}
