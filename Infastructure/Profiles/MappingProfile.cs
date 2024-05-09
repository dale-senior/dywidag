using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dywidag.Infastructure.Models;

namespace dywidag.Infastructure.Profiles
{
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<KeyValuePair<int, string>, LeapYearDto>().ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Key))
                                                           .ForMember(dest => dest.LeapYear, opt => opt.MapFrom(src => src.Value));
    }
}     
}