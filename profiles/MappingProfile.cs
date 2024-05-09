using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dywidag.Infastructure.Models;

namespace dywidag.profiles
{
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<KeyValuePair<int, bool>, LeapYearDto>().ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Key))
                                                        .ForMember(dest => dest.LeapYear, opt => opt.MapFrom(src => src.Value));
    }
}     
}