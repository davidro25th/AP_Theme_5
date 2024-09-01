using AP_Theme_5.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;


namespace GrpcService1.Services
{
    public class AlarmServices : Alarm.AlarmBase
    {
        public override Task<AlarmDTO> CreateAlarm(CreateAlarmRequest request, ServerCallContext context)
        {
            return base.CreateAlarm(request, context);
        }
        public override Task<NullableAlarmDTO> GetAlarm(GetRequest request, ServerCallContext context)
        {
            return base.GetAlarm(request, context);
        }
        public override Task<Alarms> GetAllAlarms(Empty request, ServerCallContext context)
        {
            return base.GetAllAlarms(request, context);
        }
        public override Task<Empty> UpdateAlarm(AlarmDTO request, ServerCallContext context)
        {
            return base.UpdateAlarm(request, context);
        }
        public override Task<Empty> DeleteAlarm(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteAlarm(request, context);
        }
    }
}
