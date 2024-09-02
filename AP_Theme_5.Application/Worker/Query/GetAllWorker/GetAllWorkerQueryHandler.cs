using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using MediatR;

namespace AP_Theme_5.Application.Worker.Query.GetAllWorker
{
    public class GetAllWorkerQueryHandler : IQueryHandler<GetAllWorkerQuery, IEnumerable<Domain.Entities.Configuration_Data.Worker>>
    {
        private readonly IWorkerRepository _workerrepository;
        public GetAllWorkerQueryHandler( IWorkerRepository workerRepository )
        {
            _workerrepository = workerRepository; 
        }

        Task<IEnumerable<Domain.Entities.Configuration_Data.Worker>> IRequestHandler<GetAllWorkerQuery, IEnumerable<Domain.Entities.Configuration_Data.Worker>>.Handle(GetAllWorkerQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_workerrepository.GetAllWorkers());
        }
    }
}
