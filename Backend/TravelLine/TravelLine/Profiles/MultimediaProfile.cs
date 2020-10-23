using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.DTOs;
using TravelLine.Models;

namespace TravelLine.Profiles
{
    public class MultimediaProfile : Profile
    {
        public MultimediaProfile()
        {
            CreateMap<Multimedia, MultimediaReadDto>();
            CreateMap<MultimediaCreateDto, Multimedia>();
        }
    }
}
