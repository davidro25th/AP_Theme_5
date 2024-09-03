using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Application.MeasurementUnit.Commands.CreateMeasurementUnit;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Entities.Configuration_Data.Commands.CreateMeasurementUnit
{
    public class CreateMeasurementUnitCommandHandler :
        ICommandHandler<CreateMeasurementUnitCommand, Domain.Entities.Configuration_Data.MeasurementUnit>
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeasurementUnitCommandHandler(IMeasurementUnitRepository measurementUnitRepository, IUnitOfWork unitOfWork)
        {
            _measurementUnitRepository = measurementUnitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.Entities.Configuration_Data.MeasurementUnit> Handle(CreateMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Configuration_Data.MeasurementUnit result = new Domain.Entities.Configuration_Data.MeasurementUnit( request.unitName, request.unitType );
            _measurementUnitRepository.AddMeasurementUnit( result );
            _unitOfWork.SaveChanges();

            return Task.FromResult( result );
        }


    }

    

}
