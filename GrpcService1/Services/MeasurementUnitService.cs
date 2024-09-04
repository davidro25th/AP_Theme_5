using AP_Theme_5.Application.MeasurementUnit.Commands.CreateMeasurementUnit;
using AP_Theme_5.Application.MeasurementUnit.Query.GetMeasurementUnitByID;
using AP_Theme_5.Application.MeasurementUnit.Query.GetAllMeasurementUnit;
using AP_Theme_5.Application.MeasurementUnit.Commands.UpdateMeasurementUnit;
using AP_Theme_5.Application.MeasurementUnit.Commands.DeleteMeasurementUnit;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces.Repositories.Types;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GrpcService1.Services
{
    public class MeasurementUnitService : MeasurementUnit.MeasurementUnitBase
    {
        
        

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MeasurementUnitService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IMeasurementUnitRepository _measurementUnitRepository;

        public override Task<MeasurementUnitDTO> CreateMeasurementUnit(CreateMeasurementUnitRequest request, ServerCallContext context)
        {
            
            
                // Your business logic here
                var command = new CreateMeasurementUnitCommand(
               request.Unitname,
               request.Unittype
               );
                var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<MeasurementUnitDTO>(result));
        }
        public override Task<NullableMeasurementUnitDTO> GetMeasurementUnit(GetRequest request, ServerCallContext context)
        {
            var query = new GetMeasurementUnitByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableMeasurementUnitDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableMeasurementUnitDTO() { MeasurementUnit = _mapper.Map<MeasurementUnitDTO>(result) });
        }
        public override Task<MeasurementUnits> GetAllMeasurementUnits(Empty request, ServerCallContext context)
        {
            var query = new GetAllMeasurementUnitQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de UM al mensaje de lista de DTOs de UM.
            var motorcyclesDTOs = new MeasurementUnits();
            motorcyclesDTOs.Items.AddRange(result.Select(m => _mapper.Map<MeasurementUnitDTO>(m)));

            return Task.FromResult(motorcyclesDTOs);
        }
        public override Task<Empty> UpdateMeasurementUnit(MeasurementUnitDTO request, ServerCallContext context)
        {
            var command = new UpdateMeasurementUnitCommand(_mapper.Map<AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteMeasurementUnit(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteMeasurementUnitCommand(new Guid(request.Id));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }  
    }
}
