using AutoMapper;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.GrpcProtos;
using MediatR;

namespace GrpcService1.Mappers
{
    public class MeasurementUnitProfile : Profile
    {
        public MeasurementUnitProfile()
        {
            CreateMap<AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit, AP_Theme_5.GrpcProtos.MeasurementUnitDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Unitname, o => o.MapFrom(s => s.UnitName))
                .ForMember(t => t.Unittype, o => o.MapFrom(s => s.UnitType));

            CreateMap<AP_Theme_5.GrpcProtos.MeasurementUnitDTO, AP_Theme_5.Domain.Entities.Configuration_Data.MeasurementUnit>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)) )
                .ForMember(t => t.UnitName, o => o.MapFrom(s => s.Unitname))
                .ForMember(t => t.UnitType, o => o.MapFrom(s => s.Unittype));

        }
           

    }
  

}

//TODO Fix Measurement Unit proto implementing unitname instead of unitName