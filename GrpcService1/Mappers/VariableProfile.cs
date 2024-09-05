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
                 .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                 .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                 .ForMember(t => t.Measurementunit, o => o.MapFrom(s => new AP_Theme_5.GrpcProtos.MeasurementUnitDTO()
                 {
                     Id = s.MeasurementUnit.Id.ToString(),
                     Unitname = s.MeasurementUnit.UnitName,
                     Unittype = s.MeasurementUnit.UnitType,
                 }));

            CreateMap<AP_Theme_5.GrpcProtos.VariableDTO, AP_Theme_5.Domain.Entities.Configuration_Data.Variable>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.MeasurementUnit, o => o.MapFrom(s => new AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit(s.Measurementunit.Unitname, s.Measurementunit.Unittype)));

        }
        

    }
}
