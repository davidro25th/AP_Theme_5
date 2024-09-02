using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Worker.Commands.DeleteWorker
{
    public class DeleteWorkerCommandHandler : ICommandHandler<DeleteWorkerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkerRepository _workerRepository;

        public DeleteWorkerCommandHandler(IUnitOfWork unitOfWork, IWorkerRepository workerRepository)
        {
            _unitOfWork = unitOfWork;
            _workerRepository = workerRepository;
        }

        public Task Handle(DeleteWorkerCommand request, CancellationToken cancellationToken) 
        {
            var WorkerToDelete = _workerRepository.GetWorkerById(request.id);
            if (WorkerToDelete == null)
               return Task.CompletedTask;
            
            _workerRepository.DeleteWorker(WorkerToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }

    

}
