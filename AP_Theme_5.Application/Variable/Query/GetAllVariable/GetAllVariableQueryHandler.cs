using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using MediatR;

namespace AP_Theme_5.Application.Variable.Query.GetAllVariable
{
    public class GetAllVariableQueryHandler : IQueryHandler<GetAllVariableQuery, IEnumerable<Domain.Entities.Configuration_Data.Variable>>
    {
        private readonly IVariableRepository _variablerepository;
        public GetAllVariableQueryHandler( IVariableRepository variableRepository )
        {
            _variablerepository = variableRepository; 
        }

        Task<IEnumerable<Domain.Entities.Configuration_Data.Variable>> IRequestHandler<GetAllVariableQuery, IEnumerable<Domain.Entities.Configuration_Data.Variable>>.Handle(GetAllVariableQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variablerepository.GetAllVariables());
        }
    }
}
