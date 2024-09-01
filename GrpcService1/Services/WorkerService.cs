using AP_Theme_5.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class WorkerService : Worker.WorkerBase
    {
        public override Task<WorkerDTO> CreateWorker(CreateWorkerRequest request, ServerCallContext context)
        {
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
    }
}
