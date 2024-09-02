using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Application.Variable.Commands.UpdateVariable;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Variable.Commands.Variable
{
    public class VariableCommandHandler :
        ICommandHandler<UpdateVariableCommand>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VariableCommandHandler(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle( UpdateVariableCommand request, CancellationToken cancellationToken)
        {
            _variableRepository.UpdateVariable(request.variable);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

        
    }
}
