using AP_Theme_5.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class MeasurementUnitService : MeasurementUnit.MeasurementUnitBase
    {
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
    }
}
