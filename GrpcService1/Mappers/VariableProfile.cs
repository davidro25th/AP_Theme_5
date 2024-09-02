using AutoMapper;
using MediatR;

namespace GrpcService1.Mappers
{
    public class VariableProfile : Profile
    {
        public VariableProfile()
        {
           CreateMap<AP_Theme_5.Domain.Entities.Configuration_Data.Variable, AP_Theme_5.GrpcProtos.VariableDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Name, o => o.MapFrom(t => t.Name))
                .ForMember(t => t.Code, o => o.MapFrom(t => t.Code))
                .ForMember(t => t.Measurementunit, o => o.MapFrom(s => new AP_Theme_5.GrpcProtos.MeasurementUnits())); ;

            CreateMap<AP_Theme_5.Domain.Types.MeasurementUnit, AP_Theme_5.GrpcProtos.MeasurementUnitDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Unitname, o => o.MapFrom(t => t.UnitName))
                .ForMember(t => t.Unittype, o => o.MapFrom(t => t.UnitType));

        }
        

    }
}
