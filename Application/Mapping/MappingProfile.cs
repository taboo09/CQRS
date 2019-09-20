using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domains to Dtos and reverse
            CreateMap<Homes, HomeDto>().ReverseMap();
            CreateMap<Staffs, StaffDto>().ReverseMap();
            CreateMap<Qualifications, QualDto>().ReverseMap();

            // Command to Domains
            CreateMap<Home.Edit.Command, Homes>();
        }
    }
}