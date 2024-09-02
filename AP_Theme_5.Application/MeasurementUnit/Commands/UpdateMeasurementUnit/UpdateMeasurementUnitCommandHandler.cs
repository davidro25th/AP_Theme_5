using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.MeasurementUnit.Commands.UpdateMeasurementUnit
{
    public class UpdateMeasurementUnitCommandHandler :
        ICommandHandler<UpdateMeasurementUnitCommand>
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMeasurementUnitCommandHandler(IMeasurementUnitRepository measurementUnitRepository, IUnitOfWork unitOfWork)
        {
            _measurementUnitRepository = measurementUnitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle( UpdateMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            _measurementUnitRepository.UpdateMeasurementUnit(request.measurementUnit);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

        
    }
}
