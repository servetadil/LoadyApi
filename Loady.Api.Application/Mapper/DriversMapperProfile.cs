using AutoMapper;
using Loady.Api.Application.Dto;
using Loady.Api.Core.Entities;

namespace Loady.Api.Application.Mapper
{
    public class DriversMapperProfile : Profile
    {
        public DriversMapperProfile()
        {
            CreateMap<Driver, DriverDto>()
                .ForMember(x => x.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(x => x.Country, opts => opts.MapFrom(src => src.Location.Country))
                .ForMember(x => x.City, opts => opts.MapFrom(src => src.Location.City))
                .ForMember(x => x.Surname, opts => opts.MapFrom(src => src.Surname));
        }
    }
}
