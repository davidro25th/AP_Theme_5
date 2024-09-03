using AP_Theme_5.Application.Worker.Commands.CreateWorker;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class WorkerService : Worker.WorkerBase
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkerService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {                  
            _workerRepository = workerRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<WorkerDTO> CreateWorker(CreateWorkerRequest request, ServerCallContext context)
        {
            var command = AP_Theme_5.Domain.Entities.Configuration_Data.Worker.Create(request.IdentityCard);
            var result = _mediator.Send(command).Result;

            return base.CreateWorker(request, context);
        }
        public override Task<NullableWorkerDTO> GetWorker(GetRequest request, ServerCallContext context)
        {
            return base.GetWorker(request, context);
        }
        public override Task<Workers> GetAllWorkers(Empty request, ServerCallContext context)
        {
            return base.GetAllWorkers(request, context);
        }
        public override Task<Empty> UpdateWorker(WorkerDTO request, ServerCallContext context)
        {
            return base.UpdateWorker(request, context);
        }
        public override Task<Empty> DeleteWorker(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteWorker(request, context);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkerService(IMediator _mediator, IMapper _mapper)
        {
            _mediator = _mediator;
            _mapper = _mapper;
        }


    }
}
