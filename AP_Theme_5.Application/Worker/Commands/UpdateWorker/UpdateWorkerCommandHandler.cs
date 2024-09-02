using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Application.Worker.Commands.UpdateWorker;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Worker.Commands.Worker
{
    public class WorkerCommandHandler :
        ICommandHandler<UpdateWorkerCommand>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkerCommandHandler(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle( UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            _workerRepository.UpdateWorker(request.worker);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

        
    }
}
