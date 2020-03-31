using AutoMapper;
using Domain.Models;
using Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile: Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<UserModel, UserDtoCreate>().ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}
