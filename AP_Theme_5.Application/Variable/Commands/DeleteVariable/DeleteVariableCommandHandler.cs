using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Variable.Commands.DeleteVariable
{
    public class DeleteVariableCommandHandler : ICommandHandler<DeleteVariableCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVariableRepository _variableRepository;

        public DeleteVariableCommandHandler(IUnitOfWork unitOfWork, IVariableRepository variableRepository)
        {
            _unitOfWork = unitOfWork;
            _variableRepository = variableRepository;
        }

        public Task Handle(DeleteVariableCommand request, CancellationToken cancellationToken) 
        {
            var VariableToDelete = _variableRepository.GetVariableById(request.id);
            if (VariableToDelete == null)
               return Task.CompletedTask;
            
            _variableRepository.DeleteVariable(VariableToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }

    

}
