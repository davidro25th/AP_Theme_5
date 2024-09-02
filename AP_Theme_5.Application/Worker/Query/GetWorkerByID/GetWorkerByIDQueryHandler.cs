using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Worker.Query.GetWorkerByID
{
    public class GetWorkerByIDQueryHandler : IQueryHandler<GetWorkerByIDQuery, Domain.Entities.Configuration_Data.Worker?>
    {
        private readonly IWorkerRepository _workerRepository;

        public GetWorkerByIDQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public Task<Domain.Entities.Configuration_Data.Worker?> Handle(GetWorkerByIDQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workerRepository.GetWorkerById(request.Id));
        }

    }
}
