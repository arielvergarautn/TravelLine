using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelLine.DTOs;

namespace TravelLine.DTOs
{
    public class PostReadDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public string City { get; set; }
        public DateTime StoryDate { get; set; }
        public DateTime PostDate { get; set; }
        public string Recommendations { get; set; }
        public UserReadDto User { get; set; }
        public IList<LikesReadDto> Likes { get; set; }
        public IList<MultimediaReadDto> Multimedias { get; set; }
        public IList<TagReadDto> Tags { get; set; }

    }
}