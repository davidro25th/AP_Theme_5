using AutoMapper;
using MediatR;

namespace GrpcService1.Mappers
{
    public class WorkerProfile : Profile
    {
       public WorkerProfile()
        {
           CreateMap<AP_Theme_5.Domain.Entities.Configuration_Data.Worker, AP_Theme_5.GrpcProtos.WorkerDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.IdentityCard, o => o.MapFrom(s => s.IdentityCard))
                .ForMember(t => t.Firstname, o => o.MapFrom(s => s.Firstname))
                .ForMember(t => t.Lastname, o => o.MapFrom(s => s.Lastname))
                .ForMember(t => t.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber));

            CreateMap<AP_Theme_5.GrpcProtos.WorkerDTO, AP_Theme_5.Domain.Entities.Configuration_Data.Worker>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.IdentityCard, o => o.MapFrom(s => s.IdentityCard))
                .ForMember(t => t.Firstname, o => o.MapFrom(s => s.Firstname))
                .ForMember(t => t.Lastname, o => o.MapFrom(s => s.Lastname))
                .ForMember(t => t.PhoneNumber, o => o.MapFrom(s => s.PhoneNumber));
        }
    }
}
