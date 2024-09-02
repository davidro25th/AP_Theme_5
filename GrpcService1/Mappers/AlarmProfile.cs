using AutoMapper;

namespace GrpcService1.Mappers
{
    public class AlarmProfile : Profile
    {
   
        public AlarmProfile()
        {
            CreateMap<AP_Theme_5.Domain.Entities.HistoricData.Alarm, AP_Theme_5.GrpcProtos.AlarmDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Incidencedate, o => o.MapFrom(s => s.IncidencenceDate))
                .ForMember(t => t.Recoverydate, o => o.MapFrom(s => s.RecoveryDate))
                .ForMember(t => t.Alarmconfiguration, o => o.MapFrom(s => s.AlarmConfiguration));             
                

            CreateMap<AP_Theme_5.GrpcProtos.AlarmDTO, AP_Theme_5.Domain.Entities.HistoricData.Alarm>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.IncidencenceDate, o => o.MapFrom(s => s.Incidencedate))
                .ForMember(t => t.RecoveryDate, o => o.MapFrom(s => s.Recoverydate))
                .ForMember(t => t.AlarmConfiguration, o => o.MapFrom(s => s.Alarmconfiguration));
        }
    }
}

//TODO Incidencedate x Incidencedate in Alarm
//TODO Recoverydate x RevoveryDate in Alarm