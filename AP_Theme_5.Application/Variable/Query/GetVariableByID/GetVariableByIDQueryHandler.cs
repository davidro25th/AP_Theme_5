using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Variable.Query.GetVariableByID
{
    public class GetVariableByIDQueryHandler : IQueryHandler<GetVariableByIDQuery, Domain.Entities.Configuration_Data.Variable?>
    {
        private readonly IVariableRepository _variableRepository;

        public GetVariableByIDQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<Domain.Entities.Configuration_Data.Variable?> Handle(GetVariableByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_variableRepository.GetVariableById(request.Id));
        }

    }
}
