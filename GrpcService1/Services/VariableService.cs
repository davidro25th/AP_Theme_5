using AP_Theme_5.Application.Variable.Commands.CreateVariable;
using AP_Theme_5.Application.Variable.Query.GetVariableByID;
using AP_Theme_5.Application.Variable.Query.GetAllVariable;
using AP_Theme_5.Application.Variable.Commands.UpdateVariable;
using AP_Theme_5.Application.Variable.Commands.DeleteVariable;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class VariableService : Variable.VariableBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VariableService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;
        public VariableService(IVariableRepository variableConfigurationRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = _variableRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
            var command = new CreateVariableCommand(
                request.Name,
                request.Code,
                new AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit( 
                    request.Measurementunit.Unitname,
                    request.Measurementunit.Unittype
                    )
                );
            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<VariableDTO>(result));
        }
        public override Task<NullableVariableDTO> GetVariable(GetRequest request, ServerCallContext context)
        {
            var query = new GetVariableByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableVariableDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableVariableDTO() { Variable = _mapper.Map<VariableDTO>(result) });
        }
        public override Task<Variables> GetAllVariables(Empty request, ServerCallContext context)
        {
            var query = new GetAllVariableQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de variables al mensaje de lista de DTOs de variables.
            var motorcyclesDTOs = new Variables();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<VariableDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }
        public override Task<Empty> UpdateVariable(VariableDTO request, ServerCallContext context)
        {
            var command = new UpdateVariableCommand(_mapper.Map<AP_Theme_5.Domain.Entities.Configuration_Data.Variable>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteVariable(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteVariableCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
