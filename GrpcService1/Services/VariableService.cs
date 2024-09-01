using AP_Theme_5.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class VariableService : Variable.VariableBase
    {
        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
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
    }
}
