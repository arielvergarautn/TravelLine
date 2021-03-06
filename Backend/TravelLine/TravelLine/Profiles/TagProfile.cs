﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.DTOs;
using TravelLine.Models;

namespace TravelLine.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagReadDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
