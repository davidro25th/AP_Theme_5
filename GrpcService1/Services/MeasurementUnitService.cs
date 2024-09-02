using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces.Repositories.Types;
using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;

namespace GrpcService1.Services
{
    public class MeasurementUnitService : MeasurementUnit.MeasurementUnitBase
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MeasurementUnitService(MeasurementUnitRepository measurementUnitRepository, IUnitOfWork unitOfWork)
        {
            _measurementUnitRepository = measurementUnitRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<MeasurementUnitDTO> CreateMeasurementUnit(CreateMeasurementUnitRequest request, ServerCallContext context)
        {
            return base.CreateMeasurementUnit(request, context);
        }
        public override Task<NullableMeasurementUnitDTO> GetMeasurementUnit(GetRequest request, ServerCallContext context)
        {
            return base.GetMeasurementUnit(request, context);
        }
        public override Task<MeasurementUnits> GetAllMeasurementUnits(Empty request, ServerCallContext context)
        {
            return base.GetAllMeasurementUnits(request, context);
        }
        public override Task<Empty> UpdateMeasurementUnit(MeasurementUnitDTO request, ServerCallContext context)
        {
            return base.UpdateMeasurementUnit(request, context);
        }
        public override Task<Empty> DeleteMeasurementUnit(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteMeasurementUnit(request, context);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MeasurementUnitService(IMediator _mediator, IMapper _mapper)
        {
            _mediator = _mediator;
            _mapper = _mapper;
        }

    }
}
