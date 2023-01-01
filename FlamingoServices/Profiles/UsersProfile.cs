using AutoMapper;
using FlamingoServices.Data.Models;
using FlamingoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlamingoServices.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //Source ---> Target
            CreateMap<User, UserModel>().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Userid)).
                ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Fname)).
                ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lname));

            //CreateMap<UserWriteDto, User>();
            CreateMap<UserModel, User>().ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.Username)).
                ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.Firstname)).
                ForMember(dest => dest.Lname, opt => opt.MapFrom(src => src.Lastname));
        }
    }
}
