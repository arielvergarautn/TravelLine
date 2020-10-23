using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.DTOs;
using TravelLine.Models;
using TravelLine.Profiles;

namespace TravelLine.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile() {
            CreateMap<Post, PostReadDto>();
            CreateMap<PostCreateDto, Post>();
        }
    }
}
