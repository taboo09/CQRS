using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Homes, HomeDto>().ReverseMap();
        }
    }
}