using AutoMapper;


namespace GrpcService1.Mappers
{
    public class AuditEventProfile : Profile
    {
        public AuditEventProfile()
        {
            CreateMap<AP_Theme_5.Domain.Entities.HistoricData.AuditEvent, AP_Theme_5.GrpcProtos.AuditEventDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Action, o => o.MapFrom(t => t.Action))
                .ForMember(t => t.Ocurrence, o => o.MapFrom(t => t.Ocurrence))
                .ForMember(t => t.Worker, o => o.MapFrom(t => t.Worker));

            CreateMap<AP_Theme_5.GrpcProtos.AuditEventDTO, AP_Theme_5.Domain.Entities.HistoricData.AuditEvent>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Action, o => o.MapFrom(t => t.Action))
                .ForMember(t => t.Ocurrence, o => o.MapFrom(t => t.Ocurrence))
                .ForMember(t => t.Worker, o => o.MapFrom(t => t.Worker));

        }
    }
}
