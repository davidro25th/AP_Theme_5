using AP_Theme_5.Application.Worker.Commands.CreateWorker;
using AP_Theme_5.Application.Worker.Commands.UpdateWorker;
using AP_Theme_5.Application.Worker.Query.GetWorkerByID;
using AP_Theme_5.Application.Worker.Query.GetAllWorker;
using AP_Theme_5.Application.Worker.Commands.DeleteWorker;
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

        public WorkerService() { }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkerService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IWorkerRepository _workerRepository;
       
        public override Task<WorkerDTO> CreateWorker(CreateWorkerRequest request, ServerCallContext context)
        {
            var command = AP_Theme_5.Domain.Entities.Configuration_Data.Worker.Create(request.IdentityCard);
            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<WorkerDTO>(result));
        }
        public override Task<NullableWorkerDTO> GetWorker(GetRequest request, ServerCallContext context)
        {
            var query = new GetWorkerByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableWorkerDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableWorkerDTO() { Worker = _mapper.Map<WorkerDTO>(result) });
        }
        public override Task<Workers> GetAllWorkers(Empty request, ServerCallContext context)
        {
            var query = new GetAllWorkerQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de Trabajadores al mensaje de lista de DTOs de trabajadores.
            var motorcyclesDTOs = new Workers();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<WorkerDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }
        public override Task<Empty> UpdateWorker(WorkerDTO request, ServerCallContext context)
        {
            var command = new UpdateWorkerCommand(_mapper.Map<AP_Theme_5.Domain.Entities.Configuration_Data.Worker>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteWorker(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteWorkerCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }      
    }
}
