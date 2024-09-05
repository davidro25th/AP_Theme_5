using AutoMapper;
using Google.Protobuf.WellKnownTypes;


namespace GrpcService1.Mappers
{
    public class AuditEventProfile : Profile
    {
        public AuditEventProfile()
        {
            CreateMap<DateTime, Timestamp>()
            .ConvertUsing(src => Timestamp.FromDateTime(src.ToUniversalTime()));
            CreateMap<AP_Theme_5.Domain.Entities.HistoricData.AuditEvent, AP_Theme_5.GrpcProtos.AuditEventDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Action, o => o.MapFrom(s => s.Action))
                .ForMember(t => t.Ocurrence, o => o.MapFrom(s => s.Ocurrence))
                .ForMember(t => t.Worker, o => o.MapFrom(s => s.Worker));

            CreateMap<Timestamp, DateTime>()
            .ConvertUsing(src => src.ToDateTime());

            CreateMap<AP_Theme_5.GrpcProtos.AuditEventDTO, AP_Theme_5.Domain.Entities.HistoricData.AuditEvent>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Action, o => o.MapFrom(s => s.Action))
                .ForMember(t => t.Ocurrence, o => o.MapFrom(s => s.Ocurrence))
                .ForMember(t => t.Worker, o => o.MapFrom(s => s.Worker));

        }
    }
}
