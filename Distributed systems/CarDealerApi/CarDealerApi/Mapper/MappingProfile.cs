using AutoMapper;
using CarDealerApi.Dto;
using CarDealerApi.Models;
using System.Text;

namespace CarDealerApi.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>(); 
            CreateMap<UserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password)));
            CreateMap<User, LogDto>();
            CreateMap<LogDto, User>();
        }
    }
}
