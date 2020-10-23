using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.DTOs;
using TravelLine.Models;
using AutoMapper;

namespace TravelLine.Profiles
{
    public class LikesProfile : Profile
    {
        public LikesProfile()
        {
            CreateMap<Likes, LikesReadDto>();
        }
    }
}
