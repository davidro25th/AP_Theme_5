using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.MeasurementUnit.Commands.DeleteMeasurementUnit
{
    public class DeleteMeasurementUnitCommandHandler : ICommandHandler<DeleteMeasurementUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMeasurementUnitRepository _measurementUnitRepository;

        public DeleteMeasurementUnitCommandHandler(IUnitOfWork unitOfWork, IMeasurementUnitRepository measurementUnitRepository)
        {
            _unitOfWork = unitOfWork;
            _measurementUnitRepository = measurementUnitRepository;
        }

        public Task Handle(DeleteMeasurementUnitCommand request, CancellationToken cancellationToken) 
        {
            var MeasurementUnitToDelete = _measurementUnitRepository.GetMeasurementUnitById(request.id);
            if (MeasurementUnitToDelete == null)
               return Task.CompletedTask;
            
            _measurementUnitRepository.DeleteMeasurementUnit(MeasurementUnitToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }

    

}
