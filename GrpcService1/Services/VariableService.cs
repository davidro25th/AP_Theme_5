using AP_Theme_5.Application.Variable.Commands.CreateVariable;
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
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;
        public VariableService(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
            var command = new CreateVariableCommand(
                request.Name,
                request.Code,
                new AP_Theme_5.Domain.Types.MeasurementUnit( 
                    request.Measurementunit.Unitname,
                    request.Measurementunit.Unittype
                    )
                );
            var result = _mediator.Send(command).Result;

            return base.CreateVariable(request, context);
        }
        public override Task<NullableVariableDTO> GetVariable(GetRequest request, ServerCallContext context)
        {
            return base.GetVariable(request, context);
        }
        public override Task<Variables> GetAllVariables(Empty request, ServerCallContext context)
        {
            return base.GetAllVariables(request, context);
        }
        public override Task<Empty> UpdateVariable(VariableDTO request, ServerCallContext context)
        {
            return base.UpdateVariable(request, context);
        }
        public override Task<Empty> DeleteVariable(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteVariable(request, context);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VariableService(IMediator _mediator, IMapper _mapper)
        {
            _mediator = _mediator;
            _mapper = _mapper;
        }

    }
}
