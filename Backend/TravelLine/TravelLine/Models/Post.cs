using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelLine.DTOs;

namespace TravelLine.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public DateTime StoryDate { get; set; }
        [Required]
        public DateTime PostDate { get; set; } 
        [MaxLength(500)]
        public string Recommendations { get; set; }
        public User User { get; set; }
        public IList<Likes> Likes { get; set; } = new List<Likes>();
        public IList<Tag> Tags { get; set; } = new List<Tag>();
        public IList<Multimedia> Multimedias { get; set; } = new List<Multimedia>();
    }
}