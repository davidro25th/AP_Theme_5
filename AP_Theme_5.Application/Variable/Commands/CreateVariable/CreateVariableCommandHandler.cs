using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Variable.Commands.CreateVariable
{
    public class CreateVariableCommandHandler :
        ICommandHandler<CreateVariableCommand, Domain.Entities.Configuration_Data.Variable>
    {
        private readonly IVariableRepository _measurementUnitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVariableCommandHandler(IVariableRepository measurementUnitRepository, IUnitOfWork unitOfWork)
        {
            _measurementUnitRepository = measurementUnitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.Entities.Configuration_Data.Variable> Handle(CreateVariableCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Configuration_Data.Variable result = new Domain.Entities.Configuration_Data.Variable( request.name, request.code, request.measurementUnit );
            _measurementUnitRepository.AddVariable( result );
            _unitOfWork.SaveChanges();

            return Task.FromResult( result );
        }


    }

    

}
