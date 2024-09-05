using AP_Theme_5.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace GrpcService1.Mappers
{
    public class AlarmProfile : Profile
    {

        public AlarmProfile()
        {
            CreateMap<DateTime, Timestamp>()
           .ConvertUsing(src => Timestamp.FromDateTime(src.ToUniversalTime()));
            CreateMap<AP_Theme_5.Domain.Entities.HistoricData.Alarm, AP_Theme_5.GrpcProtos.AlarmDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Incidencedate, o => o.MapFrom(s => s.IncidencenceDate))
                .ForMember(t => t.Recoverydate, o => o.MapFrom(s => s.RecoveryDate))
                .ForMember(t => t.Alarmconfiguration, o => o.MapFrom(s => new AlarmConfigurattion()
                {
                    Priority = Priority.High,
                    OutOfRange = 3,
                    VariableID = s.AlarmConfiguration.AlarmVariable.Id.ToString(),
                    VariableName = s.AlarmConfiguration.AlarmVariable.Name,
                    VariableCode = s.AlarmConfiguration.AlarmVariable.Code,
                    Muid = s.AlarmConfiguration.AlarmVariable.MeasurementUnit.Id.ToString(),
                    Muunitname = s.AlarmConfiguration.AlarmVariable.MeasurementUnit.UnitName,
                    Muunittype = s.AlarmConfiguration.AlarmVariable.MeasurementUnit.UnitType,
                }));


            CreateMap<Timestamp, DateTime>()
           .ConvertUsing(src => src.ToDateTime());
            CreateMap<AP_Theme_5.GrpcProtos.AlarmDTO, AP_Theme_5.Domain.Entities.HistoricData.Alarm>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.IncidencenceDate, o => o.MapFrom(s => s.Incidencedate))
                .ForMember(t => t.RecoveryDate, o => o.MapFrom(s => s.Recoverydate))
                .ForMember(t => t.AlarmConfiguration, o => o.MapFrom(s => s.Alarmconfiguration));
        }
    }
}