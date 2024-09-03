using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Worker.Commands.CreateWorker
{
    public class CreateWorkerCommandHandler :
        ICommandHandler<CreateWorkerCommand, Domain.Entities.Configuration_Data.Worker>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkerCommandHandler(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.Entities.Configuration_Data.Worker> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Configuration_Data.Worker result = Domain.Entities.Configuration_Data.Worker.Create(request.identityCard);
                
            _workerRepository.AddWorker(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult( result );
        }


    }

    

}
